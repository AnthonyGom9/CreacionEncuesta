using CreacionEncuesta.Models.Request;
using CreacionEncuesta.Models.Response;

namespace CreacionEncuesta.Services
{
    public interface ISelectEncuestaService
    {
        SelectEncuestaResponse SelectEncuesta(string Name);
    }
}
