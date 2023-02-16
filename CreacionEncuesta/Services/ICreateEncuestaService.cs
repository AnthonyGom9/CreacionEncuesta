using CreacionEncuesta.Models.Request;
using CreacionEncuesta.Models.Response;

namespace CreacionEncuesta.Services
{
    public interface ICreateEncuestaService
    {
        Task<CreateEncuestaResponse> CreateEncuesta(CreateEncuestaRequest model);
    }
}
