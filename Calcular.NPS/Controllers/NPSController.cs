using Calcular.NPS.Datos;
using Calcular.NPS.Modelo;
using Microsoft.AspNetCore.Mvc;


namespace Calcular.NPS.Controllers
{
    [ApiController]
    
    public class NPSController : ControllerBase
    {
        [HttpGet]
        [Route("api/calificaciones")]
        public async Task<ActionResult<List<DCalificaciones>>> Get()
        {
            var funcion = new DCalificaciones();
            var lista = await funcion.MostrarCalificaciones();
            return Ok(lista);
        }

        [HttpGet]
        [Route("api/resultadosNPS")]
        public async Task<ActionResult<List<DResultadosNPS>>> GetNPS()
        {
            var funcion = new DResultadosNPS();
            var lista = await funcion.MostrarNPS();
            return Ok(lista);
        }

        [HttpPost]
        [Route("api/insertarCalificacion")]
        public async Task<ActionResult<string>> InsertarCalificacion([FromBody] Calificacion request)
        {
            try
            {
                var funcion = new DCalificaciones();
                var respuesta = await funcion.InsertarCalificacion(request);

                return Ok(respuesta.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Se produjo un error al procesar su solicitud.", error = ex.Message });
            }
        }

    }
}
