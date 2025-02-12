using System.ComponentModel.DataAnnotations;

namespace API_InfoManager.Models.DTOs.ProfesorDTO
{
    public class CreateAlumnoDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50, ErrorMessage = "Max char is 100")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Apellido is required")]
        [MaxLength(50, ErrorMessage = "Max char is 100")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Curso is required")]
        [MaxLength(50, ErrorMessage = "Max char is 100")]
        public string Curso { get; set; }

    }
}
