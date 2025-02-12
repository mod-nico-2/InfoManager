namespace API_InfoManager.Models.DTOs.ProyectoDTO
{
    public class ProyectoDTO : CreatePujaDTO
    {
        public int ID { get; set; }
        public string Creador { get; set; }
        public string Prof_Asociado { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string status { get; set; }
        public DateTime Fecha { get; set; }
        public int ID_Departamento { get; set; }
        public DateTime Fecha_Presentacion { get; set; }
        public string Aula_Presentacion { get; set; }

    }
}
