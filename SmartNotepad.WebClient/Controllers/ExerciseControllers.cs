using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using SmartNotepad.WebClient.Models;
using SmartNotepad.Data.Context;

namespace SmartNotepad.WebClient.Controllers
{
    public class ExerciseControllers : Controller
    {
        private readonly AppDbContext _context;

        public ExerciseControllers()
        {
            _context = new AppDbContext();
        } 


    }
}
