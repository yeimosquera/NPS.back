using Calcular.NPS.Datos;
using Calcular.NPS.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace Calcular.NPS.Controllers
{
    public class UsuariosController : Controller
    {
        [HttpPost]
        [Route("api/login")]
        public async Task<ActionResult<MUsuarios>> Login([FromBody] Login request)
        {
            try
            {
                var funcion = new DUsuarios();
                var usuario = await funcion.Login(request);

                if (usuario == null)
                {
                    return Unauthorized(new { message = "Credenciales de acceso invalidos." });
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here as needed
                return StatusCode(500, new { message = "Se produjo un error al procesar su solicitud.", error = ex.Message });
            }
        }
    }
}
    

