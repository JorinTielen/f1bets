using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Team
    {
        public int ID { get; set; }
        public List<Driver> Drivers { get; set; }
        public string Name { get; set; }
        public Nationality Nationality { get; set; }
        public string Chassis { get; set; }

        public int TotalStarts { get; set; }
        public int TotalWins { get; set; }
        public int TotalPodiums { get; set; }
        public int TotalPoints { get; set; }
        public int TotalWCC { get; set; }
    }
}
