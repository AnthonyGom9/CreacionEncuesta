using CreacionEncuesta.Models.Request;
using CreacionEncuesta.Models.Response;
using CreacionEncuesta.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreacionEncuesta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EncuestaController : ControllerBase
    {
        private ICreateEncuestaService _createEncuestaService;
        private IModEncuestaService _modEncuestaService;

        public EncuestaController(ICreateEncuestaService createEncuestaService, IModEncuestaService modEncuestaService)
        {
            _createEncuestaService = createEncuestaService;
            _modEncuestaService= modEncuestaService;
        }

        [HttpPost("Create/Encuesta")]
        public async Task<IActionResult> CreateEncuesta([FromBody] CreateEncuestaRequest model)
        {
            Respuesta respuesta = new Respuesta();
            var createresponse = await _createEncuestaService.CreateEncuesta(model);

            if (createresponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Ocurrio un error al insertar los datos";
                return BadRequest(respuesta);
            }
            respuesta.Exito = 1;
            respuesta.Data = createresponse;
            return Ok(respuesta);
        }

        [HttpPost("Mod/Encuesta")]
        public async Task<IActionResult> UpdateEncuesta([FromBody] ModEncuestaRequest model )
        {
            Respuesta respuesta = new Respuesta();
            var createresponse = await _modEncuestaService.ModEncuesta(model);  

            if(createresponse == null)
            {
                respuesta.Exito= 0;
                respuesta.Mensaje = "Ocurrio un error al actualizar los datos";
                return BadRequest(respuesta); 
            }
            respuesta.Exito = 1;
            respuesta.Data = createresponse;
            return Ok(respuesta);
        }
    }
}
