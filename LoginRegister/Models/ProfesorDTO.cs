using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace LoginRegister.Models
{
    public class ProfesorDTO
    {

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("dNI")]
        public string DNI { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("apellido")]
        public string Apellido { get; set; }

        [JsonPropertyName("iD_Departamento")]
        public int ID_Departamento { get; set; }

    }
}

  
  





