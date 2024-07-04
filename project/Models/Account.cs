using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace project.Models
{
    public class Account
    {
        [Required(ErrorMessage = "Enter Your Email !!")]
        [Display(Name = "Email :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Your password !!")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}