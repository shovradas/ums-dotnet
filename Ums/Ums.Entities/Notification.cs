using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ums.Framework;

namespace Ums.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Title { get; set; }
        public String Detail { get; set; }        
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public int UserId { get; set; }

        //[NotMapped]
        public virtual User User { get; set; }
    }
}
