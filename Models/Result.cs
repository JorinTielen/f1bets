using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Result
    {
        public Competition Competition { get; set; }
        public Driver Driver { get; set; }
        public int Position { get; set; }
        public int Points { get; set; }
    }
}
