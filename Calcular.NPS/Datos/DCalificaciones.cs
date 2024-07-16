using Calcular.NPS.Modelo;
using Calcular.NPS.Conexion;
using Microsoft.Data.SqlClient;
using System.Data;
namespace Calcular.NPS.Datos
{
    public class DCalificaciones
    {
        Conexionbd cn = new Conexionbd();
        public async Task<List<MCalificaciones>> MostrarCalificaciones()
        {
            var lista = new List<MCalificaciones>();
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("MostrarCalificaciones", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mcalificaciones = new MCalificaciones();
                            mcalificaciones.CalificacionID = (int)item["CalificacionID"];
                            mcalificaciones.Calificacion = (int)item["Calificacion"];
                            mcalificaciones.UsuarioID = (int)item["UsuarioID"];
                            mcalificaciones.FechaCalificacion = (DateTime?)item["FechaCalificacion"];
                            mcalificaciones.NombreUsuario = (string)item["NombreUsuario"];
                            
                            lista.Add(mcalificaciones);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<string> InsertarCalificacion(Calificacion calificacion)
        {
            try
            {
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    using (var cmd = new SqlCommand("InsertarCalificacion", sql))
                    {
                        await sql.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UsuarioID", calificacion.UsuarioID);
                        cmd.Parameters.AddWithValue("@Calificacion", calificacion.Calificar);

                        // Definir el parámetro de salida
                        var outputParam = new SqlParameter("@Resultado", SqlDbType.NVarChar,50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);

                        await cmd.ExecuteNonQueryAsync();

                        // Capturar el valor del parámetro de salida
                        string resultado = (string)cmd.Parameters["@Resultado"].Value;
                        return resultado;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejar la excepción, por ejemplo, registrar el error
                Console.WriteLine($"Error al insertar la calificación: {ex.Message}");
                throw;
            }
        }

    }
}
