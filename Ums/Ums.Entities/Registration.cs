using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ums.Entities
{    
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public double GradePoint { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Index("IX_Unique_Registrations_StudentId_CourseId", Order = 2, IsUnique = true)]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Index("IX_Unique_Registrations_StudentId_SectionId", Order = 2, IsUnique = true)]
        public int SectionId { get; set; }

        [Index("IX_Unique_Registrations_StudentId_SectionId", Order = 1, IsUnique = true)]
        [Index("IX_Unique_Registrations_StudentId_CourseId", Order = 1, IsUnique = true)]
        [Required(ErrorMessage = "This field is required")]
        public int StudentId { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
