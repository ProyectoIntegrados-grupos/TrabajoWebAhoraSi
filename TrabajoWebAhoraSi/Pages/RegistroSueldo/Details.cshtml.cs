using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrabajoWebAhoraSi.Data;
using TrabajoWebAhoraSi.Models;

namespace TrabajoWebAhoraSi.Pages.RegistroSueldo
{
    public class DetailsModel : PageModel
    {
        private readonly TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext _context;

        public DetailsModel(TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext context)
        {
            _context = context;
        }

      public Sueldo Sueldo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sueldo == null)
            {
                return NotFound();
            }

            var sueldo = await _context.Sueldo.FirstOrDefaultAsync(m => m.SueldoID == id);
            if (sueldo == null)
            {
                return NotFound();
            }
            else 
            {
                Sueldo = sueldo;
            }
            return Page();
        }
    }
}
