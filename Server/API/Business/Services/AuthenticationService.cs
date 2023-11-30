using API.Business.DTOs;
using API.Business.DTOs.AccountDTO;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NLog.Fluent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        public readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User? _user;
        public AuthenticationService(IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

       

        public async Task<IdentityResult> CreateUser(CreateUserDTO user)
        {
            var users = _mapper.Map<User>(user);
            var result = await _userManager.CreateAsync(users, user.Password);
            if (result.Succeeded)
                await _userManager.AddToRolesAsync(users, user.Roles);
            return result;
        }

        public async Task<bool> Login(LoginValidateDTO login)
        {
             _user = await _userManager.FindByNameAsync(login.UserName);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, login.Password));
            if (!result)
            {
               _user.AccessFailedCount += 1;
               await _userManager.UpdateAsync(_user);
                return false;
            }
            _user.AccessFailedCount = 0;
            await _userManager.UpdateAsync(_user);
            return true;
        }
           

       
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.Name, _user.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddDays(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"))),
                ValidateLifetime = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out
           securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
           !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
            StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }

        public async Task<TokenDTO> CreateToken(bool populateExp)
        {
                var signingCredentials = GetSigningCredentials();
                var claims = await GetClaims();
                var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
                var refreshToken = GenerateRefreshToken();
                _user.RefreshToken = refreshToken;
                if (populateExp)
                    _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
                await _userManager.UpdateAsync(_user);
                var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDTO
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

        }
        public async Task<TokenDTO> RefreshToken(TokenDTO tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user == null || user.RefreshToken != tokenDto.RefreshToken ||
            user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new Exception("Invalid client request. The tokenDto has some invalid values.");
            _user = user;
            return await CreateToken(populateExp: false);
        }

        public async Task<User> getInfo(string userId)
        {
            return await _userManager.FindByNameAsync(userId); ;
        }

        public async Task<IEnumerable<string>> getRole (string UserId)
        {
            var users =  await _userManager.FindByNameAsync(UserId);
            return await _userManager.GetRolesAsync(users);
        }
            
        public async Task<int> isUserExists(string userId)
        {
            if (userId == null)
            {
                return 0;
            }    
            else
            {
               var result =  await _userManager.FindByNameAsync(userId);
                if (result == null)
                {
                    return 1;
                }    
                else
                {
                    return -1;
                }
            }
        }

        public async Task<User> getInfoById (string? Id)
        {
            var result = await _userManager.FindByIdAsync(Id);
            return result;
        }

       
    }
}
