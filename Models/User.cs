using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage="Username is required.")]
        [MinLength(4, ErrorMessage = "Username must be 4 characters or longer.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(4, ErrorMessage = "Password must be 4 characters or longer.")]
        public string Password { get; set; }

        public bool Admin { get; set; }

        [EmailAddress]
        public string Email { get; set; }

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
