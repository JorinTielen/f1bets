﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Repositories;
using Repositories.RepositoryContexts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace f1bets.Controllers
{
    public class UserController : Controller
    {
        private UserRepository repo = new UserRepository(new UserRepositorySQLContext());
        //LOGIN PAGE
        [HttpGet]
        public IActionResult LogIn()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult LogIn(User u)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (repo.GetPassword(u.Username) == u.Password)
                    {
                        HttpContext.Session.SetString("Account", u.Username);
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception)
                {
                    
                }
                
            }
            u.Password = "";
            return View(u);
        }

        //LOG OUT
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //REGISTER PAGE
        [HttpGet]
        public IActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Account", u.Username);
                return RedirectToAction("Index", "Home");
            }
            u.Password = "";
            return View(u);
        }

        //MY PROFILE PAGE
        public IActionResult MyProfile()
        {
            return View();
        }
    }
}
