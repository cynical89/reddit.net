using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reddit.net.Models;

namespace Reddit.net.Controllers
{

    public class PostController : Controller
    {
        private readonly RnDbContext db = new RnDbContext();
        
        [Route("/CreatePost")]
        [HttpGet]
        public IActionResult CreatePost()
        {
            return View("CreatePost");
        }

        [Route("/CreatePost")]
        [Authorize]
        [HttpPost]
        public IActionResult CreatePost(PostModel post)
        {
            post.Id = new Guid();
            post.Approved = true;
            post.Subnet = "TESTING";
            post.Comments = 0;
            post.Reputation = 1;
            post.TimeAndDate = DateTime.Now;

            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
