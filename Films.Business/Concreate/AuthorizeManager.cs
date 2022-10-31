using Films.Business.Abstract;
using Films.Business.Dto;
using Films.Business.Helpers;
using Films.Entities.Concreate;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Films.Business.Concreate
{
    public class AuthorizeManager : IAuthorizeService
    {
        public AuthorizeManager(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        private List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "User", Surname = "Test", UserName = "user", Password = "123" },
            new User { Id = 1, Name = "Example", Surname = "Developer", UserName = "user456", Password = "4321" }
        };

        private readonly AppSettings _appSettings;

        public string Authorize(AuthorizeDto authorizeDto)
        {
            var user = _users.SingleOrDefault(x => x.UserName == authorizeDto.UserName && x.Password == authorizeDto.Password);

            if (user == null)
                throw new Exception("User not Found.!");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SigningKey ?? throw new Exception("Apsetting Can Not Read."));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _appSettings.Audience,
                Issuer = _appSettings.Issuer,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
