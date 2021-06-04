using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DibzNote.Models
{
    public class CategoryEdit
    {
        public int CategoryId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Title must be more than 2 chars.")]
        [MaxLength(16, ErrorMessage = "Title must be less than 16 chars.")]
        public string Title { get; set; }
    }
}
