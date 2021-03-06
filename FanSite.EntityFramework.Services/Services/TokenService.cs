using System.IdentityModel.Tokens.Jwt;
using System.Text;
using FanSite.Services.Entities;
using FanSite.Services.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FanSite.EntityFramework.Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppSettings _appSettings;

        public TokenService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public string GetToken()
        {
            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor();
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        public bool ValidateToken(string jwt)
        {
            byte[] securityKey = Encoding.UTF8.GetBytes(_appSettings.EncryptionKey);
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(jwt, new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(securityKey),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                }, out SecurityToken token);
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }


        private SecurityTokenDescriptor GetTokenDescriptor()
        {
            const int expiringDays = 7;

            byte[] securityKey = Encoding.UTF8.GetBytes(_appSettings.EncryptionKey);
            var symmetricSecurityKey = new SymmetricSecurityKey(securityKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(expiringDays),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };


            return tokenDescriptor;
        }
    }
}
