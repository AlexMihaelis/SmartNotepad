using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Application.DTOs
{
    public class ExerciseTagDTO
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public int TagId { get; set; }
    }
}
