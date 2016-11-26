using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reddit.net.Models;

namespace Reddit.net.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private readonly RnDbContext db = new RnDbContext();
        public IActionResult Index()
        {
            var subnets = db.Posts.OrderByDescending(x => x.TimeAndDate);
                ViewData["posts"] = subnets;
                return View();
        }

        [Route("/allposts")]
        public IActionResult AllPosts()
        {
            var subnets = db.Posts.OrderByDescending(x => x.TimeAndDate);
            var jsonData = JsonConvert.SerializeObject(subnets);
            if (jsonData != null)
            {
                return Ok(jsonData);
            }

            return NotFound();
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
    }
}
