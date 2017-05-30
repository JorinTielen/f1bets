using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models;
using Repositories;
using Repositories.RepositoryContexts;
using Repositories.API;
using f1bets.ViewModels;

namespace f1bets.Controllers
{
    public class AdminController : Controller
    {
        private UserRepository userRepo = new UserRepository(new UserRepositorySQLContext());
        private CompetitionRepository competitionRepo = new CompetitionRepository(new CompetitionRepositorySQLContext());
        private API api = new API();

        public IActionResult ControlPanel()
        {
            string user = HttpContext.Session.GetString("Account");
            if (user != null)
            {
                User u = userRepo.GetUser(HttpContext.Session.GetString("Account"));
                if (u.Admin == true)
                {
                    CompetitionsViewModel vm = new CompetitionsViewModel();
                    vm.Competitions = competitionRepo.GetCompetitions();
                    return View(vm);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult ControlPanel(CompetitionsViewModel model)
        {
            int round = competitionRepo.GetRoundNumberFromRaceID(model.CompetitionID);
            api.GetRaceResultsFromApi(round);
            CompetitionsViewModel vm = new CompetitionsViewModel();
            vm.Competitions = competitionRepo.GetCompetitions();
            return View(vm);
        }
    }
}