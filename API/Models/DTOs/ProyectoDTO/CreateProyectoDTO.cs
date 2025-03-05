using System.ComponentModel.DataAnnotations;

namespace DesignAPI.Models.DTOs.ProyectoDTO
{
    public class CreateProyectoDTO
    {
        [Required(ErrorMessage = "Creador is required")]
        [MaxLength(100, ErrorMessage = "Max char is 100")]
        public string Dni_Creador { get; set; }

        [MaxLength(100, ErrorMessage = "Max char is 100")]
        public string? Dni_Prof_Asociado { get; set; } 

        [Required(ErrorMessage = "Nombre is required")]
        [MaxLength(100, ErrorMessage = "Max char is 100")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripción is required")]
        [MaxLength(500, ErrorMessage = "Max char is 500")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Fecha is required")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "ID_Departamento is required")]
        public int ID_Departamento { get; set; }

        [Required(ErrorMessage = "Fecha_Presentacion is required")]
        public DateTime Fecha_Presentacion { get; set; }

        [Required(ErrorMessage = "Aula_Presentacion is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Aula_Presentacion { get; set; }
    }
}
