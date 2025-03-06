using System.Text.Json.Serialization;


namespace LoginRegister.Models
{
    public class AlumnoDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("dNI")]
        public int DNI { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("apellido")]
        public string Apellido { get; set; }

        [JsonPropertyName("curso")]
        public string Curso { get; set; }

        [JsonPropertyName("prof_Asociado")]
        public string Prof_Asociado { get; set; }

    }
}

  
  





