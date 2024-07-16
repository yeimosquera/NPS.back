namespace Calcular.NPS.Modelo
{
    public class MCalificaciones
    {
        public int CalificacionID { get; set; }
        public int UsuarioID { get; set; }
        public int Calificacion { get; set; }
        public DateTime? FechaCalificacion { get; set; }
        public string NombreUsuario { get; set; }

    }

    public class Calificacion
    {
        public int UsuarioID { get; set; }
        public int Calificar { get; set; }
       

    }
}
