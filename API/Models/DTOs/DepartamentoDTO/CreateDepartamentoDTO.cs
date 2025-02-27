using System.ComponentModel.DataAnnotations;

namespace DesignAPI.Models.DTOs.DepartamentoDTO
{
    public class CreateDepartamentoDTO
    {
        [Required(ErrorMessage = "Nombre is required")]
        [MaxLength(100, ErrorMessage = "Max char is 100")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "ID_Jefe_Deptno is required")]
        public int ID_Jefe_Deptno { get; set; }

        [Required(ErrorMessage = "Fecha_Fin_Propuesta is required")]
        public DateTime Fecha_Fin_Propuesta { get; set; }

        [Required(ErrorMessage = "Fecha_Entrega is required")]
        public DateTime Fecha_Entrega { get; set; }
    }
}
