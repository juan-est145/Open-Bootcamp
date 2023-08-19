using api_restful_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_restful_backend.Models.DataModels;

namespace api_restful_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        public AccountsController(JwtSettings jwtSettings)
        {
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
    }
}
