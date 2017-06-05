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
    public class PredictionController : Controller
    {
        private UserRepository UserRepo = new UserRepository(new UserRepositorySQLContext());
        private PredictionRepository repo = new PredictionRepository(new PredictionRepositorySQLContext());
        private CompetitionRepository CompRepo = new CompetitionRepository(new CompetitionRepositorySQLContext());

        public IActionResult Index()
        {
            return RedirectToAction("MyPredictions");
        }

        public IActionResult MyPredictions()
        {
            string username = HttpContext.Session.GetString("Account");
            User u = UserRepo.GetUser(username);
            if (u != null)
            {
                List<Prediction> p = repo.GetAllPredictions(u);
                ViewBag.MyPredictions = p;
                return View();
            }
            return RedirectToAction("LogIn", "User");
        }

        public IActionResult Place(PredictionViewModel vm)
        {
            string username = HttpContext.Session.GetString("Account");
            if (username != null)
            {
                Prediction p = new Prediction();

                p.Competition = CompRepo.GetCompetition(vm.Competition_id);
                p.User = UserRepo.GetUser(username);

                int position = 1;
                foreach (int id in vm.Driver_id)
                {
                    
                    PredictionComponent pc = new PredictionComponent();
                    pc.Driver_id = id;

                    pc.Position = position;
                    position++;

                    p.Components.Add(pc);
                }

                try
                {
                    repo.Place(p);
                    return View("Index", "Prediction");
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