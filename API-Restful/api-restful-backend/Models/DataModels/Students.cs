using System.ComponentModel.DataAnnotations;

namespace api_restful_backend.Models.DataModels
{
    public class Students : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        public DateTime DOB { get; set; }

        public ICollection<Courses> Courses { get; set; } = new List<Courses>();
    }
}
