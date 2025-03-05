using System.ComponentModel.DataAnnotations;

namespace DesignAPI.Models.DTOs.ProfesorDTO
{
    public class CreateProfesorDTO
    {
        [Required(ErrorMessage = "DNI is required")]
        public int DNI { get; set; }

        [Required(ErrorMessage = "Nombre is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "ID_Departamento is required")]
        public int ID_Departamento { get; set; }
    }
}
