using api_restful_backend.Models;
using api_restful_backend.Models.DataModels;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace api_restful_backend.Helpers
{
    public static class JWTHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccount, Guid Id)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id", userAccount.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccount.UserName),
                new Claim(ClaimTypes.Email, userAccount.EmailId),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM dddm yyy HH:mm:ss tt"))
            };

            if (userAccount.UserName == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }

            else if (userAccount.UserName == "User 1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User "));
            }

            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccount, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccount, Id);
        }

        public static UserTokens GenTokenKey(UserTokens model, JwtSettings jwtSettings)
        {
            try 
            {
                var userToken = new UserTokens();
                if (model== null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                //Obtain secret key
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);

                Guid Id;

                //Expires in 1 Day
                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                //Validity of our token
                userToken.Validity = expireTime.TimeOfDay;

                //Generate Our JWT
                var jwToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256));
                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
                userToken.GuidId = Id;
                return userToken;
            }

            catch (Exception ex) 
            {
                throw new Exception("Error generating the JWT", ex);
            }
        }
    }
}
