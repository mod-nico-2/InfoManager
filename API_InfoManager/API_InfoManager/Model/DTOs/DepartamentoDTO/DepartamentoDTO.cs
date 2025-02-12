namespace API_InfoManager.Models.DTOs.DepartamentoDTO
{
    public class DepartamentoDTO : Crete
    {
        public string nombre { get; set; }
        public int ID { get; set; }
        public int ID_Jefe_Deptno { get; set; }
        public DateTime Fecha_Fin_Propuesta { get; set; }
        public DateTime Fecha_Entrega { get; set; }

    }
}
