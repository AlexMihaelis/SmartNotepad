using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Application.DTOs
{
    public class NoteDTO
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifDate { get; set; }
        public int UserId { get; set; } 
    }
}
