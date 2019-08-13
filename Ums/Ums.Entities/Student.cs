using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ums.Entities
{
    [Table("Students")]
    public class Student: User
    {
        [Required]
        [Index(IsUnique = true)]
        public String FormattedId { get; set; }
        [Required]
        public double Cgpa { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Registration> Sections { get; set; }
    }
}
