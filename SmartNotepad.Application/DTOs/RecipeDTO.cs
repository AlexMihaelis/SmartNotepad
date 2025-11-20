using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Application.DTOs
{
    public class RecipeDTO
    {
        public string? Image { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; } 
        public int Servings { get; set; } 
        public DateTime CreationDate { get; set; } 
        public int UserId { get; set; } 
    }
}
