using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Application.DTOs
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; } 
        public int Servings { get; set; } 
        public DateOnly CreationDate { get; set; } 
        public int UserId { get; set; } 
        public int RecipeCategoryId { get; set; } 
        public int RecipeTagId { get; set; } 
    }
}
