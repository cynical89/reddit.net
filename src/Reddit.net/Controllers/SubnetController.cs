using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Reddit.net.Models;

namespace Reddit.net.Controllers
{
    public class SubnetController : Controller
    {
        private readonly RnDbContext db = new RnDbContext();

        [Route("/s/all")]
        [HttpGet]
        public IActionResult All()
        {
            var subnets = db.Subnets;
            ViewData["subnets"] = subnets;
            return View();
        }

        [Route("s/{id}")]
        public IActionResult ViewSubnet(string id)
        {
            List<PostModel> postObject = new List<PostModel>();
            var posts = db.Posts;
            foreach (var post in posts)
            {
                if (post.Subnet == id)
                {
                    postObject.Add(post);
                }
            }
            var subnets = db.Subnets;
            foreach (var subnet in subnets)
            {
                if (subnet.Name == id)
                {
                    ViewData["posts"] = postObject;
                    ViewData["subnet"] = subnet;
                    return View("ViewSubnet");
                }
            }
            return NotFound();
            
        }

        [Route("CreateSubnet")]
        [HttpGet]
        public IActionResult CreateSubnet()
        {
            return View();
        }

        [Route("CreateSubnet")]
        [Authorize]
        [HttpPost]
        public IActionResult CreateSubnet(SubnetModel subnet)
        {
            subnet.Language = SubnetModel.Languages.English;
            subnet.Type = SubnetModel.AccessType.Public;
            subnet.Over18Only = false;
            subnet.VisibleInAll = true;

            db.Subnets.Add(subnet);
            db.SaveChanges();
            return RedirectToAction("All", "Subnet");
        }
    }
}
