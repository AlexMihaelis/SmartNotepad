using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CookingTime { get; set; } // В минутах будет
        public int Servings { get; set; } // Кол-во порций
        public DateOnly CreationDate { get; set; }
        public int UserId { get; set; } // FK User
        public User User { get; set; } // НП
        public IEnumerable<RecipeCategory> RecipeCategories { get; set; } // НП
        public IEnumerable<RecipeTag> RecipeTags { get; set; } // НП
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
