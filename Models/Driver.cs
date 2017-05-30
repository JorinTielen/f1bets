using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Driver
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int DriverNumber { get; set; }
        public Nationality Nationality { get; set; }

        public int TotalStarts { get; set; }

        public int TotalWins { get; set; }
        public int TotalPolepositions { get; set; }
        public int TotalFastestLaps { get; set; }

        public int TotalPodiums { get; set; }
        public int TotalPoints { get; set; }
        public int TotalWDC { get; set; }

        public Driver()
        {
        }
    }
}
