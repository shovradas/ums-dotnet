using System;
using System.ComponentModel.DataAnnotations;

namespace Ums.Entities
{
    public class DomainConfig
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Config { get; set; }
    }
}
