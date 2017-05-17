using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Required]
        [MinLength(6)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [EmailAddress]
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
