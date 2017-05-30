using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Prediction
    {
        public int FirstDriver_id { get; set;}
        public int SecondDriver_id { get; set; }
        public int ThirdDriver_id { get; set; }

        public User User { get; private set; }
        public Competition Competition { get; private set; }

        public Prediction(User user, Competition competition)
        {
            this.User = user;
            this.Competition = competition;
        }
    }
}
