using CreacionEncuesta.Models.Request;
using CreacionEncuesta.Models.Response;

namespace CreacionEncuesta.Services
{
    public interface IModEncuestaService
    {
        Task<ModEncuestaResponse> ModEncuesta(ModEncuestaRequest model);
    }
}
