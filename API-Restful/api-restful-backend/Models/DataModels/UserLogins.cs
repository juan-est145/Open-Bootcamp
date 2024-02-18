using System.ComponentModel.DataAnnotations;

namespace api_restful_backend.Models.DataModels
{
    public class UserLogins
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string password { get; set; }

    }
}
