using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNotepad.Domain.Models
{
    public class RecipeTag
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
