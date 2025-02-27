using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignAPI.Models.Entity
{
    public class ProyectoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Dni_Creador { get; set; }

        [MaxLength(100)]
        public string? Dni_Prof_Asociado { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descripcion { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int ID_Departamento { get; set; }

        [Required]
        public DateTime Fecha_Presentacion { get; set; }

        [Required]
        [MaxLength(50)]
        public string Aula_Presentacion { get; set; }
    }
}