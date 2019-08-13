using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ums.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public String Code { get; set; }
        [Required]
        public double Credit { get; set; }
        [Required(ErrorMessage = "Department filed is required")]
        public int DepartmentId { get; set; }

        //[NotMapped]
        public virtual Department Department { get; set; }
        //[NotMapped]
        public virtual ICollection<Section> Sections { get; set; }
    }
}
