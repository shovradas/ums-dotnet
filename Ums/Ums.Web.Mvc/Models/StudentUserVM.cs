//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;

//namespace Ums.Web.Mvc.Models
//{
//    public class StudentUserVM
//    {
//        [Key]
//        public int Id { get; set; }
//        [Required]
//        public String Name { get; set; }
//        [Required]
//        [Index(IsUnique = true)]
//        public String UserName { get; set; }
//        [Required]
//        public String Password { get; set; }
//        [Required]
//        public UserType Type { get; set; }
//        [Required]
//        [Index(IsUnique = true)]
//        public String Email { get; set; }
//        [Required(ErrorMessage = "This field is required")]
//        public bool IsActive { get; set; }


//        [Key]
//        [Required]
//        public String Id { get; set; }
//        [Required]
//        public double Cgpa { get; set; }
//        [Required]
//        public int DepartmentId { get; set; }
//        [Required(ErrorMessage = "This field is required")]
//        public int UserId { get; set; }

//        public virtual User User { get; set; }
//        public virtual Department Department { get; set; }
//        public virtual ICollection<Section> Sections { get; set; }
//    }
//}