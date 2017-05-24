using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Details(int id)
        {
            try
            {
                Competition c = repo.GetCompetition(id);
                return View(c);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}