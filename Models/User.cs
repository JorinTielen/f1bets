using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public User(int id, string username, string password, string email)
        {
            this.ID = id;
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }

        public User()
            :this("","")
        {
        }
    }
}
