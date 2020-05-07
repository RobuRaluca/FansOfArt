using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication16.Models;

namespace RCA3.Controllers
{
    public class AdminsController : Controller
    {
        private readonly ApplicationUser _auc;

        public AdminsController(ApplicationUser auc)
        {
            _auc = auc;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAdmin(Admin uc)
        {
            _auc.Add(uc);
            _auc.SaveChanges();
            ViewBag.message = "The Admin " + uc.AdminName + " is saved succesfully";
            return View();
        }
    }
}