using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Data.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "The Summary cannot exceed 32 characters. ")]
        public string Title { get; set; }

        [Required]
        [StringLength(1200, ErrorMessage = "The Summary cannot exceed 1200 characters. ")]
        public string Summary { get; set; }

        public int StudentId { get; set; }
        public string StudentUsername { get; set; }
    }
}
