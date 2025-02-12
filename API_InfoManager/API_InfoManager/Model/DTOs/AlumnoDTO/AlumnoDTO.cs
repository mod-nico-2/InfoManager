using API_InfoManager.Models.DTOs.AlumnoDTO;

namespace API_InfoManager.Models.DTOs.AlumnoDTO
{
    public class AlumnoDTO : CreateAlumnoDTO
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Curso { get; set; }
        public string Prof_Asociado { get; set; }

    }
}
