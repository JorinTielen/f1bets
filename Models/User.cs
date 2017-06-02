using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        public int ID { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }

        public bool Admin { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public List<User> Friends { get; set; }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public User(int id, string username, string password, string email, bool admin)
        {
            this.ID = id;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Admin = admin;
        }

        public User()
            :this("","")
        {
        }
    }
}
