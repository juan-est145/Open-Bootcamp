using System.ComponentModel.DataAnnotations;

namespace api_restful_backend.Models.DataModels
{
    public class UserLogins
    {
        [Required]
        public string userName { get; set; }
        public string password { get; set; }

    }
}
