using System.Text.Json.Serialization;

namespace DesignAPI.Models.DTOs.ProfesorDTO
{
    public class ProfesorDTO : CreateProfesorDTO
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public int ID_Departamento { get; set; }

    }
}
