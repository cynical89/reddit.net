using System;
using System.Collections.Generic;
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
            var subnets = db.Subnets;
            ViewData["subnets"] = subnets;
            return View("CreatePost");
        }

        [Route("/CreatePost")]
        [Authorize]
        [HttpPost]
        public IActionResult CreatePost(PostModel post)
        {
            post.Id = new Guid();
            post.Approved = true;
            post.Comments = 0;
            post.Reputation = 1;
            post.TimeAndDate = DateTime.Now;

            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Route("s/{sName}/{id}")]
        public IActionResult ViewPost(string sName, Guid id)
        {
            Guid sid = Guid.Empty;
            var subnets = db.Subnets;
            foreach (var subnet in subnets)
            {
                if (subnet.Name == sName)
                {
                    sid = subnet.Id;
                }
            }
            if (sid == Guid.Empty)
            {
                return NotFound();
            }

            var post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            if (sName != post.Subnet)
            {
                return NotFound();
            }

            List<CommentModel> comObject = new List<CommentModel>();
            var comments = db.Comments;
            foreach (var comment in comments)
            {
                if (comment.ParentPost == post.Id)
                {
                    comObject.Add(comment);
                }
            }

            ViewData["comments"] = comObject;
            ViewData["post"] = post;
            return View("ViewPost");
        }
    }
}
