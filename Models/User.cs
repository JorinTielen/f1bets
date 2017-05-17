using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public User()
            :this("","")
        {
        }
    }
}
