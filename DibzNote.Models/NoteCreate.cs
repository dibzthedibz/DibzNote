using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DibzNote.Models
{
    public class NoteCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Title must be longer than 2 characters.")]
        [MaxLength(100, ErrorMessage = "Title Too Long.")]
        public string Title { get; set; }
        [MaxLength(8000)]
        public string Content { get; set; }
    }
}
