﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Circuit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Nationality Nationality { get; set; }
        public TimeSpan Laprecord { get; set; }
    }
   
}
