using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Competition
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Race { get; set; }
        public DateTime Date { get; set; }

        public Circuit Circuit { get; set; }
        
    }
}
