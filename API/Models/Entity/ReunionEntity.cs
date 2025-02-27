using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignAPI.Models.Entity
{
    public class ReunionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int ID_Alumno { get; set; }

        [Required]
        public int ID_Profe { get; set; }

        [Required]
        public int ID_Proyecto { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [MaxLength(50)]
        public string Aula { get; set; }
    }
}