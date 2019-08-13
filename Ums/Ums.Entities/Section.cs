using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ums.Entities
{
    public class Section
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int CourseId { get; set; }

        //[NotMapped]
        public virtual Course Course { get; set; }
        //[NotMapped]
        //[ForeignKey("StudentId")]
        public virtual ICollection<Registration> Students { get; set; }
    }
}
