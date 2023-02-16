using CreacionEncuesta.Models.Request;
using CreacionEncuesta.Models.Response;

namespace CreacionEncuesta.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
