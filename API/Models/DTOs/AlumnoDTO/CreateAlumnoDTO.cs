using System.ComponentModel.DataAnnotations;

namespace DesignAPI.Models.DTOs.AlumnoDTO
{
    public class CreateAlumnoDTO
    {
        [Required(ErrorMessage = "DNI is required")]
        public int DNI { get; set; }

        [Required(ErrorMessage = "Nombre is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Curso is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Curso { get; set; }

        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string? Prof_Asociado { get; set; }

    }
}
