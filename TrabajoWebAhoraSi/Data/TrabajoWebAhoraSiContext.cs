using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrabajoWebAhoraSi.Models;

namespace TrabajoWebAhoraSi.Data
{
    public class TrabajoWebAhoraSiContext : DbContext
    {
        public TrabajoWebAhoraSiContext (DbContextOptions<TrabajoWebAhoraSiContext> options)
            : base(options)
        {
        }

        public DbSet<TrabajoWebAhoraSi.Models.Empleado> Empleado { get; set; } = default!;

        public DbSet<TrabajoWebAhoraSi.Models.Cargo>? Cargo { get; set; }

        public DbSet<TrabajoWebAhoraSi.Models.Sueldo>? Sueldo { get; set; }
    }
}
