using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateOnly RegistrDate { get; set; }
        public DateOnly DateBirth { get; set; }
        public IEnumerable<Note> Notes { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }
        public IEnumerable<Board> Boards { get; set; }
    }
}
