using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter Your First Name!!")]
        [Display(Name = "First Name :")]
        [StringLength(maximumLength: 9, MinimumLength = 3, ErrorMessage = "First Name Must be More than 3 and less than 9")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Your Last Name!!")]
        [Display(Name = "Last Name :")]
        [StringLength(maximumLength: 9, MinimumLength = 3, ErrorMessage = "Last Name Must be More than 3 and less than 9")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter Your Email !!")]
        [Display(Name = "Email :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Your password !!")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Your Repassword !!")]
        [Display(Name = "RePassword :")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Select Your Gender !!")]
        [Display(Name = "Gender :")]
        public string Gender { get; set; }
        
        //[Required(ErrorMessage = "Upload Profile image !!")]
        [Display(Name = "Profile Image :")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Enter Your Mobile !!")]
        [Display(Name = "Mobile :")]
        public string Mobile { get; set; }

        [NotMapped]
        public HttpPostedFileBase imageFile { get; set; }
    }
}