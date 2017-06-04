using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using System.ComponentModel.DataAnnotations;


namespace f1bets.ViewModels
{
    public class UpdateUserViewModel : User
    {
        [Required]
        [MinLength(4, ErrorMessage = "Your username must be 4 or more characters long.")]
        [MaxLength(33)]
        public override string Username { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Your password must be 4 or more characters long.")]
        [MaxLength(33)]
        public override string Password { get; set; }
        [Required]
        [EmailAddress]
        public override string Email { get; set; }
    }
}
