using CreacionEncuesta.Models;
using CreacionEncuesta.Models.Request;
using CreacionEncuesta.Models.Response;

namespace CreacionEncuesta.Services
{
    public class CreateEncuestaService : ICreateEncuestaService

    {
        private readonly DataBaseAcmeContext _context;
        public CreateEncuestaService(DataBaseAcmeContext context)
        {
            _context = context;
        }

        public async Task<CreateEncuestaResponse> CreateEncuesta(CreateEncuestaRequest model)
        {
            CreateEncuestaResponse createEncuestaResponse = new CreateEncuestaResponse();
            var DetalleEncuesta = new DetalleEncuestum();
            try
            {
                var createid = "encuesta_" + model.usuario_registro.ToString();
                foreach (DetalleEncuestum data in model.detalle)
                {
                    DetalleEncuesta = new DetalleEncuestum()
                    {
                        IdDetalle = createid,
                        Nombre = data.Nombre,
                        Titulo = data.Titulo,
                        Requerido = Convert.ToInt32(data.Requerido),
                        Resultado = data.Resultado,
                        EstadoRegistro = Convert.ToInt32(data.EstadoRegistro)
                    };

                    _context.DetalleEncuesta.Add(DetalleEncuesta);
                    await _context.SaveChangesAsync();


                }
                var Encuesta = new Encuestum()
                {
                    Titulo = model.titulo,
                    Descripcion = model.descripcion,
                    DetalleEncuesta = createid,
                    UsuarioRegistro = model.usuario_registro,
                    EstadoRegistro = model.estado_registro
                };
                _context.Encuesta.Add(Encuesta);
                await _context.SaveChangesAsync();
                createEncuestaResponse.Link = "https://localhost:7190/api/User/Encuesta?Name=" + createid;
                createEncuestaResponse.Nombre = "Nombre Encuesta";
            }
            catch(Exception ex)
            {
                return null;
            }
            return createEncuestaResponse;
        }
    }
}
