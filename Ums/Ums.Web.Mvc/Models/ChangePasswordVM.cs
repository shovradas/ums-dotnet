using System;
using System.ComponentModel.DataAnnotations;

namespace Ums.Web.Mvc.Models
{
    public class ChangePasswordVM
    {
        [Required]
        public String UserName { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String NewPassword { get; set; }
        [Required]
        [Compare("NewPassword", ErrorMessage = "Confirmed password did not match")]
        public String ConfirmPassword { get; set; }
    }
}