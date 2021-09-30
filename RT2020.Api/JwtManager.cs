using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Tokens;

namespace RT2020.Api
{
    /*
       參考：http://stackoverflow.com/questions/40281050/jwt-authentication-for-asp-net-web-api
       Source: https://github.com/cuongle/WebApi.Jwt
       Notes: Needs changes on WebApiConfig & include all files under Filters, apply with [AllowAnonymous] or [JwtAuthentication] in your controllers
       Basic Authenticatio, steps:
       1. call ~/api/token?username=xxx&password=xxx
          returns the toaken
       2. call ~/api/{controller} with header parameters: key = Authorization, value = Bearer XXXX-token-XXXX...
    */
    class JwtManager
    {
    public const string Secret = "DC5D718FFEE74D2EB8A1BF087B204B52"; // random guid used as symetric

        public static string GenerateToken(string username, int expireMinutes = 0)
        {
            expireMinutes = expireMinutes == 0 ? int.Parse(ConfigurationManager.AppSettings["Token_Expiration"]) : expireMinutes;

            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, username)
                        }),

                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(Secret);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }

            catch (Exception)
            {
                return null;
            }
        }
    }
}
