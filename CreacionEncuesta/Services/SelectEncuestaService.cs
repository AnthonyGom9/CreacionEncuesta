using CreacionEncuesta.Models;
using CreacionEncuesta.Models.Request;
using CreacionEncuesta.Models.Response;

namespace CreacionEncuesta.Services
{
    public class SelectEncuestaService : ISelectEncuestaService
    {
        private readonly DataBaseAcmeContext _context;
        public SelectEncuestaService(DataBaseAcmeContext context)
        {
            _context = context;
        }
        public SelectEncuestaResponse SelectEncuesta(string Name)
        {
            SelectEncuestaResponse selectencuesta = new SelectEncuestaResponse();
            var DetalleEncuesta = new DetalleEncuestum();
            List<DetalleEncuestum> listdata = new List<DetalleEncuestum>();
            try
            {
                var filterencuesta = _context.Encuesta.Where(d=> d.DetalleEncuesta == Name).FirstOrDefault();
                var detallefilter = _context.DetalleEncuesta.Where(d=> d.IdDetalle == Name).ToList();

                foreach(DetalleEncuestum det in detallefilter)
                {
                    DetalleEncuesta = new DetalleEncuestum();
                    DetalleEncuesta.Nombre = det.Nombre; 
                    DetalleEncuesta.Titulo = det.Titulo;
                    listdata.Add(DetalleEncuesta);
                }
                selectencuesta.Titulo = filterencuesta.Titulo;
                selectencuesta.Descripcion = filterencuesta.Descripcion;
                selectencuesta.DetalleEncuesta = listdata;

            }catch (Exception ex) {
                return null;
            }
            return selectencuesta;
        }
    }
}
