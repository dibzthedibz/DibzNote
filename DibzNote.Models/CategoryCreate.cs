using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DibzNote.Models
{
    public class CategoryCreate
    {
        [Required]
        [MinLength(6, ErrorMessage = "Category Title must be more than six characters.")]
        [MaxLength(16, ErrorMessage = "Category Title too long.")]
        public string Title { get; set; }
    }
}
