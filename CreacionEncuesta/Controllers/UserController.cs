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
//    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private ICreateEncuestaService _createEncuestaService;

        public UserController(IUserService userService, ICreateEncuestaService createEncuestaService)
        {
            _userService = userService;
            _createEncuestaService = createEncuestaService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Respuesta respuesta = new Respuesta();
            var userresponse = _userService.Auth(model);

            if(userresponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o contraseña incorrecta";
                return BadRequest(respuesta);
            }
            respuesta.Exito = 1;
            respuesta.Data = userresponse;

            return Ok(respuesta);
        }

        [HttpPost("Create/Encuesta")]
        public async Task<IActionResult> CreateEncuesta([FromBody] CreateEncuestaRequest model)
        {
            Respuesta respuesta = new Respuesta();
            var createresponse = await _createEncuestaService.CreateEncuesta(model);

            if(createresponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Ocurrio un error al insertar los datos";
                return BadRequest(respuesta);
            }
            respuesta.Exito = 1;
            respuesta.Data = createresponse;
            return Ok(respuesta);
        }
    }
}
