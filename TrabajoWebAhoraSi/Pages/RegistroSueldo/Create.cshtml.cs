using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrabajoWebAhoraSi.Data;
using TrabajoWebAhoraSi.Models;

namespace TrabajoWebAhoraSi.Pages.RegistroSueldo
{
    public class CreateModel : PageModel
    {
        private readonly TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext _context;

        public CreateModel(TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "EmpleadoId", "Apellido");
            return Page();
        }

        [BindProperty]
        public Sueldo Sueldo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sueldo == null || Sueldo == null)
            {
                return Page();
            }

            _context.Sueldo.Add(Sueldo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
