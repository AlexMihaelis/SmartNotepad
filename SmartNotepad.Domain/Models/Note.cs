using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifDate { get; set; }
        public int UserId { get; set; } // Внешний ключ User
        public User User { get; set; } // Навигационное свойство
        public IEnumerable<NoteCategory> NoteCategories { get; set; } // Навигационное свойство
        public IEnumerable<NoteTag> NoteTags { get; set; } // Навигационное свойство
    }
}
