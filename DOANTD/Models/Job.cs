using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANTD.Models
{
    public class Job 
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string SalaryRange { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Requirements { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.Now;
    }
}