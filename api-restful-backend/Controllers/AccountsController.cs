using api_restful_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_restful_backend.Models.DataModels;
using api_restful_backend.Helpers;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using api_restful_backend.DataAccess;

namespace api_restful_backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly API_OpenBootcamp_context _context;
        private readonly JwtSettings _jwtSettings;
        public AccountsController(API_OpenBootcamp_context context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }

        private IEnumerable<Users> Logins = new List<Users>()
        {
            new Users()
            {
                Id = 1,
                EmailAddress = "martin@gmail.com",
                Name = "Admin",
                Password = "Admin"
            },
            new Users()
            {
                Id = 2,
                EmailAddress = "juan@gmail.com",
                Name = "User1",
                Password = "Prueba"
            }
        };
        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {
                var Token = new UserTokens();
                
                var Valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                if (Valid)
                {
                    var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                    Token = JWTHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = user.Name,
                        EmailId = user.EmailAddress,
                        Id = user.Id,
                        GuidId = Guid.NewGuid()
                    }, _jwtSettings);  
                }
                else
                {
                    return BadRequest("Wrong Password");
                }
                return Ok(Token);
            }
            catch (Exception ex) 
            {
                throw new Exception("GetToken Error", ex);
            }
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }
    }
}
