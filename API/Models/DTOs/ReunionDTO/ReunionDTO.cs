namespace DesignAPI.Models.DTOs.ReunionDTO
{
    public class ReunionDTO : CreateReunionDTO
    {
        public int ID { get; set; }
        public int ID_Alumno { get; set; }
        public int ID_Profe { get; set; }
        public int ID_Proyecto { get; set; }
        public DateTime Fecha { get; set; }
        public string aula { get; set; }

    }
}
