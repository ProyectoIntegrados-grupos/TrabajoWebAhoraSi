using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Agrega esta directiva

namespace TrabajoWebAhoraSi.Models
{
    public class Sueldo
    {
        [Required(ErrorMessage = "ID es necesario")]
        public int SueldoID { get; set; }

        public int DescuentoIV { get; set; }
        public int Bono { get; set; }
        public int DescuentoSeguro { get; set; }

        [Required(ErrorMessage = "Empleado es necesario")]
        public int EmpleadoId { get; set; } // Relación con Empleado

        [ForeignKey("EmpleadoId")] // Define la relación con la clave foránea
        public Empleado Empleado { get; set; } // La propiedad de navegación hacia Empleado
    }
}
