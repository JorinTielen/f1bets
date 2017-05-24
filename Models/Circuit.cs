using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Circuit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public TimeSpan Laprecord { get; set; }
    }
   
}
