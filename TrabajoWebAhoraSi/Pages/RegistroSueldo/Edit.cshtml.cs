using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabajoWebAhoraSi.Data;
using TrabajoWebAhoraSi.Models;

namespace TrabajoWebAhoraSi.Pages.RegistroSueldo
{
    public class EditModel : PageModel
    {
        private readonly TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext _context;

        public EditModel(TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sueldo Sueldo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sueldo == null)
            {
                return NotFound();
            }

            var sueldo =  await _context.Sueldo.FirstOrDefaultAsync(m => m.SueldoID == id);
            if (sueldo == null)
            {
                return NotFound();
            }
            Sueldo = sueldo;
           ViewData["EmpleadoId"] = new SelectList(_context.Empleado, "EmpleadoId", "Apellido");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sueldo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SueldoExists(Sueldo.SueldoID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SueldoExists(int id)
        {
          return (_context.Sueldo?.Any(e => e.SueldoID == id)).GetValueOrDefault();
        }
    }
}
