using System;
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
using f1bets.ViewModels;

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
                    return RedirectToAction("LogIn", "User");
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
                try
                {
                    repo.CreateUser(u.Username, u.Password, u.Email);
                    HttpContext.Session.SetString("Account", u.Username);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {
                    return RedirectToAction("LogIn", "User");
                }
            }
            u.Password = "";
            return View(u);
        }

        //PROFILE PAGE
        public IActionResult Profile(string username)
        {
            try
            {
                User u = repo.GetUser(username);
                if (u != null)
                {
                    return View(u);
                }
                else
                {
                    return View("UserNotFound");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("LogIn", "User");
            }
        }

        //SETTINGS PAGE
        public IActionResult Settings()
        {
            try
            {
                User u = repo.GetUser(HttpContext.Session.GetString("Account"));
                return View(u);
            }
            catch (Exception)
            {
                return RedirectToAction("LogIn", "User");
            }
        }

        [HttpPost]
        public IActionResult Settings(User u)
        {
            try
            {
                u.ID = repo.GetID(HttpContext.Session.GetString("Account"));
                repo.EditUser(u.ID, u.Username, u.Password, u.Email);
                HttpContext.Session.SetString("Account", u.Username);
            }
            catch (Exception)
            {
                return RedirectToAction("LogIn", "User");
            }
            return View(u);
        }

        public IActionResult Friends()
        {
            string username = HttpContext.Session.GetString("Account");
            if (username != "" && username != null)
            {
                try
                {
                    User u = repo.GetUser(username);
                    FriendsViewModel vm = new FriendsViewModel(u);
                    vm.Friends = repo.GetAcceptedFriends(u.ID);
                    vm.Pending = repo.GetPendingUserFriends(u.ID);
                    vm.Waiting = repo.GetWaitingUserFriends(u.ID);
                    if (u != null)
                    {
                        return View(vm);
                    }
                }
                catch (Exception)
                {
                }
            }
            return RedirectToAction("LogIn", "User");
        }

        public IActionResult Unfriend(int? id)
        {
            string username = HttpContext.Session.GetString("Account");
            if (username != "" && username != null)
            {
                try
                {
                    User u = repo.GetUser(username);
                    //repo.Unfriend(u, id);
                    //repo.UpdateUserFriend(u, id);

                    return RedirectToAction("Friends");
                }
                catch (Exception)
                {
                }
            }
            return RedirectToAction("LogIn", "User");
        }

        public IActionResult Accept(int? id)
        {
            string username = HttpContext.Session.GetString("Account");
            if (username != "" && username != null)
            {
                try
                {
                    User u = repo.GetUser(username);
                    repo.AcceptUserFriend(u, id);

                    return RedirectToAction("Friends");
                }
                catch (Exception)
                {
                }
            }
            return RedirectToAction("LogIn", "User");
        }
    }
}
