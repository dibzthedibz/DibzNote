﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DibzNote.Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public List<NoteListItem> Notes { get; set; }
    }
}
