using Calcular.NPS.Conexion;
using Calcular.NPS.Modelo;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Calcular.NPS.Datos
{
    public class DResultadosNPS
    {

        Conexionbd cn = new Conexionbd();
        public async Task<List<MResultadosNPS>> MostrarNPS()
        {
            var lista = new List<MResultadosNPS>();
            using (var SqlCommand = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("MostrarResultadosNPS", SqlCommand))
                {
                    await SqlCommand.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mcalificaciones = new MResultadosNPS();
                            //mcalificaciones.ResultadoID = (int)item["ResultadoID"];
                            mcalificaciones.NPS = (int)item["NPS"];
                            mcalificaciones.FechaCalculo = (DateTime?)item["FechaCalculo"];
                            lista.Add(mcalificaciones);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
