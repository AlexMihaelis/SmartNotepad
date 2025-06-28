using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Models
{
    public class NoteCategory
    {
        public int NoteId { get; set; }
        public Note Note { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
