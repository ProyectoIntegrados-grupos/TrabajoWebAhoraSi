using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TrabajoWebAhoraSi.Models
{
    public class Cargo
    {
        [Required(ErrorMessage = "ID es necesario")]
        public int CargoId { get; set; }

        [Required(ErrorMessage = "Nombre de Cargo es necesario")]
        [StringLength(50, ErrorMessage = "El nombre de Cargo debe tener como máximo 50 caracteres.")]
        public string Nombre_de_Cargo { get; set; }

        [Required(ErrorMessage = "Tipo de Cargo es necesario")]
        [StringLength(50, ErrorMessage = "El tipo de Cargo debe tener como máximo 50 caracteres.")]
        public string Tipo_de_Cargo { get; set; }

        [Required(ErrorMessage = "Sueldo Fijo es necesario")]
        [Range(0, int.MaxValue, ErrorMessage = "El Sueldo Fijo debe ser un valor no negativo.")]
        public int SueldoID { get; set; }// FK

        [ForeignKey("SueldoID")] // Define la relación con la clave foránea
        public Sueldo Sueldo { get; set; } // La propiedad de navegación hacia Sueldo
    }
}
