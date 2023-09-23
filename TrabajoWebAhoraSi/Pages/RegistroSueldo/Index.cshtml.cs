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
    public class IndexModel : PageModel
    {
        private readonly TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext _context;

        public IndexModel(TrabajoWebAhoraSi.Data.TrabajoWebAhoraSiContext context)
        {
            _context = context;
        }

        public IList<Sueldo> Sueldo { get;set; } = default!;
       /* [BindProperty(SupportsGet = true)]
        public int? SearchInt { get; set; }
        public SelectList? Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? IdSuelso { get; set; }*/
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Ids { get; set; }

        [BindProperty(SupportsGet = true)]
        public string IdSueldo { get; set; }
        public async Task OnGetAsync()
        {
            /*if (_context.Sueldo != null)
            {
                Sueldo = await _context.Sueldo
                .Include(s => s.Empleado).ToListAsync();
            }
            IQueryable<int> apequery = from n in _context.Sueldo
                                          orderby n.SueldoID
                                          select n.SueldoID;

            var nom = from n in _context.Sueldo
                      select n;

            if (!string.IsNullOrEmpty(SearchInt))
            {
                nom = nom.Where(s => s.SueldoID.Contains(SearchInt));
            }

            if (!string.IsNullOrEmpty(SearchInt))
            {
                nom = nom.Where(x => x.SueldoID == IdSuelso);
            }
            Id = new SelectList(await apequery.Distinct().ToListAsync());
            Sueldo = await nom.ToListAsync();*/
            IQueryable<int> sueldoIdsQuery = from sueldo in _context.Sueldo
                                             orderby sueldo.SueldoID
                                             select sueldo.SueldoID;

            var sueldoQuery = from sueldo in _context.Sueldo
                              select sueldo;

            if (!string.IsNullOrEmpty(SearchString))
            {
                sueldoQuery = sueldoQuery.Where(s => s.SueldoID.ToString().Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(IdSueldo))
            {
                sueldoQuery = sueldoQuery.Where(x => x.SueldoID.ToString() == IdSueldo);
            }

            Ids = new SelectList(await sueldoIdsQuery.Distinct().ToListAsync());
            Sueldo = await sueldoQuery.ToListAsync();
        }
    }
}
