using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using f1bets.ViewModels;
using Models;
using Repositories;
using Repositories.RepositoryContexts;

namespace f1bets.Controllers
{
    public class CompetitionController : Controller
    {
        private CompetitionRepository repo = new CompetitionRepository(new CompetitionRepositorySQLContext());
        public IActionResult Index()
        {
            try
            {
                List<Competition> competitions = repo.GetUpcomingCompetitions();
                return View(competitions);
            }
            catch (Exception)
            {
                //connection error page
                return View("Error");
            }
        }

        public IActionResult History()
        {
            try
            {
                List<Competition> pastCompetitions = repo.GetPastCompetitions();
                return View(pastCompetitions);
            }
            catch (Exception)
            {
                //connection error page
                return View("Error");
            }
        }

        public IActionResult Details(int id)
        {
            try
            {
                DetailsViewModel vm = new DetailsViewModel();
                vm.Competition = repo.GetCompetition(id);
                vm.Drivers = repo.GetDrivers();
                if (vm.Competition.Date < DateTime.Now)
                {
                    vm.Results = repo.GetResultsFromRace(vm.Competition.ID);
                }
                ViewBag.CompetitionData = vm;
                return View(new Prediction());
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Details(int id, Prediction p)
        {
            try
            {
                DetailsViewModel vm = new DetailsViewModel();
                vm.Competition = repo.GetCompetition(id);
                if (vm.Competition.Date < DateTime.Now)
                {
                    vm.Results = repo.GetResultsFromRace(vm.Competition.ID);
                }
                return View(vm);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}