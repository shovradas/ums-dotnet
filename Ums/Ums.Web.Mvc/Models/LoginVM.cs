using System;
using System.ComponentModel.DataAnnotations;

namespace Ums.Web.Mvc.Models
{
    public class LoginVM
    {
        [Required]
        public String UserName { get; set; }
        [Required]
        public String Password { get; set; }
        public String Remember { get; set; }        
    }
}