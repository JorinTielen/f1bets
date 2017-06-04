using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Prediction
    {
        public List<PredictionComponent> Components { get; set; } = new List<PredictionComponent>();

        public User User { get; set; }
        public virtual Competition Competition { get; set; }

        public Prediction()
        {
        }

        public Prediction(User user, Competition competition, List<PredictionComponent> components)
        {
            this.User = user;
            this.Competition = competition;
            this.Components = components;
        }
    }
}
