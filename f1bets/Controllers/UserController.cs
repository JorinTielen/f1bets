using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Models;
using Microsoft.AspNetCore.Http;
using Repositories;
using Repositories.RepositoryContexts;
using f1bets.ViewModels;

namespace f1bets.Controllers
{
    public class UserController : Controller
    {
        private UserRepository repo = new UserRepository(new UserRepositorySQLContext());
        //LOGIN PAGE
        [HttpGet]
        public IActionResult LogIn()
        {
            return View(new LogInUserViewModel());
        }

        [HttpPost]
        public IActionResult LogIn(LogInUserViewModel u)
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
                    return View("Error");
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
            return View(new UpdateUserViewModel());
        }

        [HttpPost]
        public IActionResult Register(UpdateUserViewModel u)
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
                    return View("Error");
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
                    u.Friends = repo.GetAcceptedFriends(u.ID);
                    ViewBag.LoggedInUser = repo.GetUser(HttpContext.Session.GetString("Account"));
                    ViewBag.LoggedInUser.Friends = repo.GetAcceptedFriends(ViewBag.LoggedInUser.ID);
                    
                    ViewBag.ProfileType = DetermineProfileType(u, ViewBag.LoggedInUser);
                    PredictionRepository tempRepo = new PredictionRepository(new PredictionRepositorySQLContext());
                    ViewBag.Predictions = tempRepo.GetAllPredictions(u);
                    return View(u);
                }
                else
                {
                    return View("UserNotFound");
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        public ProfileType DetermineProfileType(User ProfileUser, User LoggedInUser)
        {
            if (ProfileUser.Username == LoggedInUser.Username)
            {
                //is this my profile?
                return ProfileType.Mine;
            }
            else if (ViewBag.LoggedInUser.Friends.Count == 0)
            {
                //i have no friends so he can't be my friend
                return ProfileType.Stranger;
            }
            else
            {
                foreach (var friend in LoggedInUser.Friends)
                {
                    if (friend.Username == ProfileUser.Username)
                    {
                        return ProfileType.Friend;
                    }
                }
            }
            return ProfileType.Stranger;
        }

        //SETTINGS PAGE
        public IActionResult Settings()
        {
            try
            {
                User u = repo.GetUser(HttpContext.Session.GetString("Account"));
                UpdateUserViewModel vm = new UpdateUserViewModel();
                vm.Username = u.Username;
                vm.Password = u.Password;
                vm.Email = u.Email;
                vm.ID = u.ID;
                return View(vm);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Settings(UpdateUserViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vm.ID = repo.GetID(HttpContext.Session.GetString("Account"));
                    repo.EditUser(vm.ID, vm.Username, vm.Password, vm.Email);
                    HttpContext.Session.SetString("Account", vm.Username);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View(vm);
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
                    return View("Error");
                }
            }
            return RedirectToAction("LogIn", "User");
        }

        public IActionResult AddFriend(int? id)
        {
            string username = HttpContext.Session.GetString("Account");
            if (username != "" && username != null)
            {
                try
                {
                    User u = repo.GetUser(username);
                    repo.AddFriend(u, id);

                    User friend = repo.GetUser(Convert.ToInt32(id));
                    return RedirectToAction("Friends");
                }
                catch (Exception)
                {
                    return View("Error");
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
                    repo.DeleteUserFriend(u, id);

                    return RedirectToAction("Friends");
                }
                catch (Exception)
                {
                    return View("Error");
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
                    return View("Error");
                }
            }
            return RedirectToAction("LogIn", "User");
        }

        public IActionResult Decline(int? id)
        {
            string username = HttpContext.Session.GetString("Account");
            if (username != "" && username != null)
            {
                try
                {
                    User u = repo.GetUser(username);
                    repo.DeleteUserFriend(u, id);

                    return RedirectToAction("Friends");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }
            return RedirectToAction("LogIn", "User");
        }
    }
}
