using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Application.DTOs
{
    public class RecipeCategoryDTO
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int CategoryId { get; set; }
    }
}
