using CreacionEncuesta.Models;
using CreacionEncuesta.Models.Request;
using CreacionEncuesta.Models.Response;

namespace CreacionEncuesta.Services
{
    public class ModEncuestaService: IModEncuestaService
    {
        private readonly DataBaseAcmeContext _context;
        public ModEncuestaService(DataBaseAcmeContext context)
        {
            _context = context;
        }

        public async Task<ModEncuestaResponse> ModEncuesta(ModEncuestaRequest model)
        {
            ModEncuestaResponse modEncuestaRes = new ModEncuestaResponse();
            var DetalleEncuesta = new DetalleEncuestum();
            try
            {
                var EncuestaSelect = _context.DetalleEncuesta.SingleOrDefault(d => d.IdDetalle == model.Nombre_Encuesta);
                EncuestaSelect.Nombre = model.nombre;
                EncuestaSelect.Titulo = model.Titulo;
                EncuestaSelect.Requerido = model.Requerido;
                await _context.SaveChangesAsync();
                modEncuestaRes.NombreEncuesta = model.Nombre_Encuesta;
                modEncuestaRes.Mensaje = "La encuesta ha sido actualizada";
                
            }
            catch (Exception ex) {
                return null;
            }
            return modEncuestaRes;

        }
    }
}
