using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace f1bets.ViewModels
{
    public class ResultsViewModel
    {
        public Competition Competition { get; set; }
        public List<Result> Results { get; set; }
    }
}
