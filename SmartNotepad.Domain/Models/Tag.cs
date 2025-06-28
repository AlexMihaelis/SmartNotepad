using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ExerciseTag> ExerciseTags { get; set; }
        public IEnumerable<RecipeTag> RecipeTags { get; set; }
        public IEnumerable<NoteTag> NoteTags { get; set; }
    }
}
