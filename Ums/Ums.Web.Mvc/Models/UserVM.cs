using System;
using System.ComponentModel.DataAnnotations;

namespace Ums.Web.Mvc.Models
{
    public class UserVM
    {
        [Required]
        public String UserName { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Email { get; set; }
    }
}