using Microsoft.IdentityModel.Tokens;
using School.Data.Helper;
using School.Data.Models.Identity;
using School.Service.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace School.Service.Implementaion
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(nameof(UserCalim.UserName),user.UserName),
                new Claim(nameof(UserCalim.Email),user.Email),
                new Claim(nameof(UserCalim.PhoneNumber),user.PhoneNumber),
            };
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.issuer,
                _jwtSettings.audience,
                claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return Task.FromResult(accessToken);

        }
    }
}
