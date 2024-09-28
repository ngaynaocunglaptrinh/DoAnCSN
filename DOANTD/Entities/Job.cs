using System;
using System.ComponentModel.DataAnnotations;

namespace DOANTD.Entities
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public string Company { get; set; }

        [Required]
        [MaxLength(255)]
        public string Location { get; set; }

        [Required]
        [MaxLength(255)]
        public string SalaryRange { get; set; }

        [Required]
        [MaxLength(100)]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Requirements { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.Now;
    }
}