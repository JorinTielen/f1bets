using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PredictionComponent
    {
        public int ID { get; set; }

        public int Driver_id { get; set; }
        public Driver Driver { get; set; }
        public int Position { get; set; }
        public bool Checked { get; set; }
        public bool Correct { get; set; }
    }
}
