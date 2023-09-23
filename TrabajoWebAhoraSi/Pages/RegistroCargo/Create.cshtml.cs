using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrabajoWebAhoraSi.Data;
using TrabajoWebAhoraSi.Models;

namespace TrabajoWebAhoraSi.Pages.RegistroCargo
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
        ViewData["SueldoID"] = new SelectList(_context.Set<Sueldo>(), "SueldoID", "SueldoID");
            return Page();
        }

        [BindProperty]
        public Cargo Cargo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Cargo == null || Cargo == null)
            {
                return Page();
            }

            _context.Cargo.Add(Cargo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
