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
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private ISelectEncuestaService _selectEncuestaService;
        

        public UserController(IUserService userService, ISelectEncuestaService selectEncuestaService)
        {
            _userService = userService;
            _selectEncuestaService = selectEncuestaService;
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

        [HttpGet("Encuesta")]
        public IActionResult GetEncuesta([FromHeader] string Name)
        {
            Respuesta respuesta = new Respuesta();
            var userresponse = _selectEncuestaService.SelectEncuesta(Name);   

            if(userresponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Ha ocurrido un error al consultar la encuesta";
                return BadRequest(respuesta);
            }
            respuesta.Exito = 1;
            respuesta.Data = userresponse;

            return Ok(respuesta);
        }
    }
}
