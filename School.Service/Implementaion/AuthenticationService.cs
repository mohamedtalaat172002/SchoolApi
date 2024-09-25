using Microsoft.IdentityModel.Tokens;
using School.Data.Helper;
using School.Data.Models.Identity;
using School.Data.Result;
using School.infrastructure.Abstract;
using School.Service.Abstract;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace School.Service.Implementaion
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenInfrastrucure _refreshTokenInfrastrucure;
        private readonly ConcurrentDictionary<string, RefreshToken> _UserRefreshTokenDictionary;
        public AuthenticationService(JwtSettings jwtSettings, IRefreshTokenInfrastrucure refreshTokenInfrastrucure)
        {
            _jwtSettings = jwtSettings;
            _UserRefreshTokenDictionary = new ConcurrentDictionary<string, RefreshToken>();
            _refreshTokenInfrastrucure = refreshTokenInfrastrucure;
        }

        public async Task<JwtResult> GenerateJwtToken(User user)
        {
            var jwtToken = GetJwtSecurityToken(user);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var RefreshTokenObj = GetRefreshTokenObj(user);
            _UserRefreshTokenDictionary.AddOrUpdate(RefreshTokenObj.RefreshTokenString, RefreshTokenObj, (K, v) => RefreshTokenObj);
            var JwtResultObj = new JwtResult
            {
                AccessToken = accessToken,
                RefreshToken = RefreshTokenObj,
            };
            var userRefreshToken = new UserRefreshToken
            {
                AddedTime = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                IsUsed = false,
                IsRevoked = false,
                JwtId = jwtToken.Id,
                RefreshToken = RefreshTokenObj.RefreshTokenString,
                Token = accessToken,
                UserId = user.Id
            };

            await _refreshTokenInfrastrucure.AddAsync(userRefreshToken);



            return (JwtResultObj);

        }

        public JwtSecurityToken GetJwtSecurityToken(User user)
        {
            var claims = GetClaims(user);
            return new JwtSecurityToken(_jwtSettings.issuer,
                _jwtSettings.audience,
                claims,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.secret)), SecurityAlgorithms.HmacSha256Signature)
                );
        }

        public List<Claim> GetClaims(User user)
        {
            return new List<Claim>
            {
                new Claim(nameof(UserCalim.UserName),user.UserName),
                new Claim(nameof(UserCalim.Email),user.Email),
                new Claim(nameof(UserCalim.PhoneNumber),user.PhoneNumber),
            };
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private RefreshToken GetRefreshTokenObj(User user)
        {
            return new RefreshToken
            {
                UserName = user.UserName,
                RefreshTokenString = GenerateRefreshToken(),
                ExpiredAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate)
            };
        }
    }
}
