namespace Calcular.NPS.Modelo
{
    public class MUsuarios
    {
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Perfil { get; set; }

    }

    public class Login
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }
}
