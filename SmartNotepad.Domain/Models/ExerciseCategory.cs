using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Models
{
    public class ExerciseCategory
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
