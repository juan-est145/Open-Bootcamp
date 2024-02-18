using System.ComponentModel.DataAnnotations;

namespace api_restful_backend.Models.DataModels
{
    public class Categoría : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public ICollection<Courses> Courses { get; set; } = new List<Courses>();
    }
}
