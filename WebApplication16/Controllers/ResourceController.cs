using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication16.Models;

namespace WebApplication16.Controllers

{
    public class ResourceController : Controller
    {
        private readonly ApplicationResource _res;


        public ResourceController(ApplicationResource res)
        {
            _res = res;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateResource()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateResource(Resource r)
        {
            _res.Add(r);
            _res.SaveChanges();

            ViewBag.message = "The Resource " + r.ResourceName + " is saved succesfully";
            return View();
        }
    }
}