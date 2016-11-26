using System;
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

        [Route("s/all")]
        [HttpGet]
        public IActionResult All()
        {
            var subnets = db.Subnets;
            ViewData["subnets"] = subnets;
            ViewData["disableSubnetLink"] = true;
            return View();
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
