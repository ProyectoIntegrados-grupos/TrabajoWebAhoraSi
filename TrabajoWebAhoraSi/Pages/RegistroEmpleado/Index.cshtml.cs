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

namespace TrabajoWebAhoraSi.Pages.RegistroEmpleado
{
    public class IndexModel : PageModel
    {
        private readonly TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext _context;

        public IndexModel(TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext context)
        {
            _context = context;
        }

        public IList<Empleado> Empleado { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Apellido { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ApellidoEmpleado { get; set; }
        public async Task OnGetAsync()
        {
            /*if (_context.Empleado != null)
            {
                Empleado = await _context.Empleado.ToListAsync();
            }*/
            IQueryable<string> apequery = from n in _context.Empleado
                                          orderby n.Apellido
                                          select n.Apellido;
            var nom = from n in _context.Empleado
                      select n;
            if (!string.IsNullOrEmpty(SearchString))
            {
                nom = nom.Where(s => s.Apellido.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                nom = nom.Where(x => x.Apellido == ApellidoEmpleado);
            }
            Apellido = new SelectList(await apequery.Distinct().ToListAsync());
            Empleado = await nom.ToListAsync();
        }
    }
}
