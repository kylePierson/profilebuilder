using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Critter.Web.Models
{
    public class ChangePasswordViewModel
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Current Password:")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "New Password:")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password:")]
        public string ConfirmPassword { get; set; }
    }
}