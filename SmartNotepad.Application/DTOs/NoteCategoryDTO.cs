using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Application.DTOs
{
    public class NoteCategoryDTO
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public int CategoryId { get; set; }
    }
}
