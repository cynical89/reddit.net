using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reddit.net.Models;

namespace Reddit.net.Controllers
{
    public class CommentController : Controller
    {
        private readonly RnDbContext db = new RnDbContext();

        [HttpPost]
        [Authorize]
        public IActionResult CreateComment(CommentModel model)
        {
            model.Id = new Guid();
            
            db.Comments.Add(model);
            db.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
