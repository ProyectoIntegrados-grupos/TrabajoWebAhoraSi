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
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [BindProperty(SupportsGet = true)]
        public string ? SearchString {get; set; }
        public SelectList ? Nombre { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ?NombreCargo { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> nomquery = from n in _context.Cargo
                                          orderby n.Nombre_de_Cargo
                                          select n.Nombre_de_Cargo;
            var nom = from n in _context.Cargo
                      select n;
            /*if (_context.Cargo != null)
            {
                Cargo = await _context.Cargo
                .Include(c => c.Sueldo).ToListAsync();
            }*/
            if (!string.IsNullOrEmpty(SearchString))
            {
                nom = nom.Where(s => s.Nombre_de_Cargo.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                nom = nom.Where(x => x.Nombre_de_Cargo == NombreCargo);
            }
            Nombre = new SelectList(await nomquery.Distinct().ToListAsync());
            Cargo = await nom.ToListAsync();
        }
    }
}
