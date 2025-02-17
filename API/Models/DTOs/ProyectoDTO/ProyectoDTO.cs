namespace API.Models.DTOs.ProyectoDTO
{
    public class ProyectoDTO : CreateProyectoDTO
    {
        public int Id { get; set; }
        public string Dni_alumno { get; set; }
        public string Dni_profesor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Status { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_Departamento { get; set; }
        public DateTime Fecha_Presentacion { get; set; }
        public string Aula_Presentacion { get; set; }

    }
}
