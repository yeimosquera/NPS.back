
namespace Calcular.NPS.Conexion
{
    public class Conexionbd
    {
        private string connectionstring = string.Empty;
        public Conexionbd()
        {
            var constructor = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionstring = constructor.GetSection("ConnectionStrings:conexion").Value;
        }

        public string CadenaSQL()
        {
            return connectionstring;
        }
    }
}
