namespace DesignAPI.Models.DTOs.ProyectoDTO
{
    public class ProyectoDTO : CreateProyectoDTO
    {
        public int ID { get; set; }
        public string Dni_Creador { get; set; }
        public string Dni_Prof_Asociado { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Status { get; set; }
        public DateTime Fecha { get; set; }
        public int ID_Departamento { get; set; }
        public DateTime Fecha_Presentacion { get; set; }
        public string Aula_Presentacion { get; set; }

    }
}
