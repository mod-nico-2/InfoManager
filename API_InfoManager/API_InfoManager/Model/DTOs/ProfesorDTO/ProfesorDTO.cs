namespace API_InfoManager.Models.DTOs.ProfesorDTO
{
    public class ProfesorDTO : CreatePujaDTO
    {
        public int DNI { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int ID_Departamento { get; set; }

    }
}
