using Calcular.NPS.Conexion;
using Calcular.NPS.Modelo;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Calcular.NPS.Datos
{
    public class DUsuarios
    {

        Conexionbd cn = new Conexionbd();

        public async Task<MUsuarios> Login(Login login)
        {
            try
            {
                var usuario = new MUsuarios();
                using (var sql = new SqlConnection(cn.CadenaSQL()))
                {
                    using (var cmd = new SqlCommand("LoginUsuario", sql))
                    {
                        await sql.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreUsuario", login.NombreUsuario);
                        cmd.Parameters.AddWithValue("@Contrasena", login.Contrasena);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                usuario.UsuarioID = reader["UsuarioID"] != DBNull.Value ? (int)reader["UsuarioID"] : 0;
                                usuario.NombreUsuario = reader["NombreUsuario"] != DBNull.Value ? (string)reader["NombreUsuario"] : string.Empty;
                                usuario.Perfil = reader["Perfil"] != DBNull.Value ? (string)reader["Perfil"] : string.Empty;
                            }
                        }
                    }
                }
                return usuario;
            }
            catch (SqlException ex)
            {
                // Manejar la excepción, por ejemplo, registrar el error
                Console.WriteLine($"Error al intentar loguearse: {ex.Message}");
                throw;
            }
        }

    }
}
