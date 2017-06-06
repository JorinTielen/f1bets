using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Reaction
    {
        public int ID { get; set; }
        public int Competition_id { get; set; }
        public User User { get; set; }
        public List<Reaction> Replies { get; set; }
        public int Replyto_id { get; set; }
        public string Text { get; set; }
    }
}
