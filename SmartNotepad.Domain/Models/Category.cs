using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ExerciseCategory> ExerciseCategories { get; set; }
        public IEnumerable<RecipeCategory> RecipeCategories { get; set; }
        public IEnumerable<NoteCategory> NoteCategories { get; set; }
    }
}
