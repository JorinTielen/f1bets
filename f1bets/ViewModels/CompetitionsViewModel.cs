using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace f1bets.ViewModels
{
    public class CompetitionsViewModel
    {
        public int CompetitionID { get; set; }
        public List<Competition> Competitions { get; set; }
    }
}
