using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using System.ComponentModel.DataAnnotations;


namespace f1bets.ViewModels
{
    public class LogInUserViewModel : User
    {
        [Required]
        public override string Username { get; set; }
        [Required]
        public override string Password { get; set; }
    }
}
