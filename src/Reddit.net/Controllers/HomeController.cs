using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reddit.net.Models;

namespace Reddit.net.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private readonly RnDbContext db = new RnDbContext();
        private readonly UserManager<UserModel> _userManager;

        public HomeController(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var subnets = db.Posts.OrderByDescending(x => x.TimeAndDate);
                ViewData["posts"] = subnets;
                return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SubnetModel topic)
        {
            if (ModelState.IsValid)
            {
                db.Subnets.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        [Authorize]
        [Route("/vote")]
        [HttpPost]
        public IActionResult Vote(VoteModel vote)
        {
            var userId = _userManager.GetUserId(User);
            vote.UserId = Guid.Parse(userId);

            var votes = db.Votes;
            foreach (var v in votes)
            {
                if (v.UserId == vote.UserId && v.ContentId == vote.ContentId)
                {
                    return Redirect(Request.Headers["Referer"].ToString());
                }
            }

            db.Votes.Add(vote);

            dynamic content = null;
            switch (vote.Type)
            {
                case VoteModel.ContentType.Subnet:
                    content = db.Subnets;
                    break;
                case VoteModel.ContentType.Post:
                    content = db.Posts;
                    break;
                case VoteModel.ContentType.Comment:
                    content = db.Comments;
                    break;
            }

            var obj = content.Find(vote.ContentId);
            obj.Reputation += vote.Point;
            content.Update(obj);

            db.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
