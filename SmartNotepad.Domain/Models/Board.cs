using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Priority { get; set; }
        public DateTime CreationDate { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
