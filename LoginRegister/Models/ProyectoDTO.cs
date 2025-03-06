using System.Text.Json.Serialization;


namespace LoginRegister.Models
{
    public class ProyectoDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("dni_Creador")]
        public string Dni_Creador { get; set; }

        [JsonPropertyName("dni_Prof_Asociado")]
        public string? Dni_Prof_Asociado { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("fecha")]
        public DateTime Fecha { get; set; }

        [JsonPropertyName("iD_Departamento")]
        public int ID_Departamento { get; set; }

        [JsonPropertyName("fecha_Presentacion")]
        public DateTime Fecha_Presentacion { get; set; }

        [JsonPropertyName("aula_Presentacion")]
        public string Aula_Presentacion { get; set; }

    }
}

  
  





