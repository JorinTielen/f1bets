using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Nationality
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
