using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int BoardId { get; set; }
        public Board Board { get; set; }
        public IEnumerable<ExerciseCategory> ExerciseCategories { get; set; } // Навигационное свойство
        public IEnumerable<ExerciseTag> ExerciseTags { get; set; } // Навигационное свойство

    }
}
