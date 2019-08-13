using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ums.Framework;

namespace Ums.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        [Index("IX_Unique_Users_UserName", IsUnique = true)]
        public String UserName { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public UserType Type { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Index("IX_Unique_Users_Email", IsUnique = true)]
        public String Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public bool IsActive { get; set; }
    }
}
