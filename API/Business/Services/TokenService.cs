using API.Business.Interfaces;
using API.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Business.Services
{
    public class TokenService : IToken
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("AppSettings:SecretKey").Value!));
        }

        public string CreateToken(Account account)
        {
            var jwtHanderToken = new JwtSecurityTokenHandler();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, account.User),
                new Claim("Id", account.Id.ToString())
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            var token = jwtHanderToken.CreateToken(tokenDescriptor);
            return jwtHanderToken.WriteToken(token);
        }
    }
}
