using System.ComponentModel.DataAnnotations;

namespace API_InfoManager.Models.DTOs.ReunionDTO
{
    public class CreateReunionDTO
    {
        [Required(ErrorMessage = "ID_Alumno is required")]
        public int ID_Alumno { get; set; }

        [Required(ErrorMessage = "ID_Profe is required")]
        public int ID_Profe { get; set; }

        [Required(ErrorMessage = "ID_Proyecto is required")]
        public int ID_Proyecto { get; set; }

        [Required(ErrorMessage = "Fecha is required")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Aula is required")]
        [MaxLength(50, ErrorMessage = "Max char is 50")]
        public string Aula { get; set; }
    }
}
