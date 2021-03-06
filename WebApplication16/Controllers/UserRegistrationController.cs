﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{ 
    public class UserRegistrationController : Controller
    {
        private readonly ApplicationUser _auc;

        public UserRegistrationController(ApplicationUser auc)
        {
            _auc = auc;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(User uc)
        {
            _auc.Add(uc);
            _auc.SaveChanges();
            ViewBag.message = "The User " +uc.UserName+ " is saved succesfully";
            return View();
        }

    }
}