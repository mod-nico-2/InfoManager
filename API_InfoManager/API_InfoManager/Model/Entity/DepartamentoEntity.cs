using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_InfoManager.Models.Entity
{
    public class DepartamentoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int ID_Jefe_Deptno { get; set; }

        [Required]
        public DateTime Fecha_Fin_Propuesta { get; set; }

        [Required]
        public DateTime Fecha_Entrega { get; set; }
    }
}