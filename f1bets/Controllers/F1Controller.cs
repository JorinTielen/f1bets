using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using Repositories.RepositoryContexts;
using f1bets.ViewModels;

namespace f1bets.Controllers
{
    public class F1Controller : Controller
    {
        private F1Repository repo = new F1Repository(new F1RepositorySQLContext());
        public IActionResult Index()
        {
            ViewBag.Drivers = repo.GetDrivers();
            ViewBag.Teams = repo.GetTeams();
            return View();
        }

        public IActionResult Drivers(int? id)
        {
            DriverViewModel vm = new DriverViewModel();
            vm.Driver = repo.GetDriver(id);
            vm.Results = repo.GetDriverResults(id);
            return View(vm);
        }

        public IActionResult Teams(int? id)
        {
            Team t = repo.GetTeam(id);
            return View(t);
        }
    }
}