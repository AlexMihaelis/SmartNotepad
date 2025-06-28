using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Models
{
    public class ExerciseTag
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
