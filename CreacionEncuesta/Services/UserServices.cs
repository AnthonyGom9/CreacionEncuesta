using CreacionEncuesta.Models;
using CreacionEncuesta.Models.Common;
using CreacionEncuesta.Models.Request;
using CreacionEncuesta.Models.Response;
using CreacionEncuesta.Tools;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CreacionEncuesta.Services
{
    public class UserServices : IUserService
    {

        private readonly DataBaseAcmeContext _context;
        private readonly AppSettings _appSettings;

        public UserServices(DataBaseAcmeContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = new UserResponse();   
            using (var db = _context )
            {
                string spassword = Encrypt.GetSHA256(model.Password);

                var usuario = db.Usuarios.Where(d=> d.Usuario1 == model.Email && d.Password == spassword).FirstOrDefault();

                if (usuario == null) return null;
                userResponse.Email = usuario.Usuario1;
                userResponse.Token = GetToken(usuario);
            }

            return userResponse;
        }

        private string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Email, usuario.Usuario1),
                    }),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
