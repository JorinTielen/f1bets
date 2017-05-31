using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace f1bets.ViewModels
{
    public class FriendsViewModel
    {
        public User User;
        public List<User> Friends { get; set; } = new List<User>();
        public List<UserFriend> Pending { get; set; } = new List<UserFriend>();
        public List<UserFriend> Waiting { get; set; } = new List<UserFriend>();


        public FriendsViewModel(User u)
        {
            this.User = u;
        }
    }
}
