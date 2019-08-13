using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ums.Entities
{    
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String Description { get; set; }
    
        //[NotMapped]
        public virtual ICollection<Student> Students { get; set; }
        //[NotMapped]
        public virtual ICollection<Course> Courses { get; set; }
    }
}
