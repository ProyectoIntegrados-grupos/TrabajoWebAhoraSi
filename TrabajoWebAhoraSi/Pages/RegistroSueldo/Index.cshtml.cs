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
    public class IndexModel : PageModel
    {
        private readonly TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext _context;

        public IndexModel(TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext context)
        {
            _context = context;
        }

        public IList<Sueldo> Sueldo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sueldo != null)
            {
                Sueldo = await _context.Sueldo
                .Include(s => s.Empleado).ToListAsync();
            }
        }
    }
}
