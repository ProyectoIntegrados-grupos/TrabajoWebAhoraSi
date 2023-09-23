using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrabajoWebAhoraSi.Data;
using TrabajoWebAhoraSi.Models;

namespace TrabajoWebAhoraSi.Pages.RegistroCargo
{
    public class IndexModel : PageModel
    {
        private readonly TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext _context;

        public IndexModel(TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext context)
        {
            _context = context;
        }

        public IList<Cargo> Cargo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cargo != null)
            {
                Cargo = await _context.Cargo
                .Include(c => c.Sueldo).ToListAsync();
            }
        }
    }
}
