using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; } // FK Unit
        public IEnumerable<Unit> Units { get; set; } // НП
        public int RecipeId { get; set; } // FK Recipe
        public Recipe Recipe { get; set; } //НП
    }
}
