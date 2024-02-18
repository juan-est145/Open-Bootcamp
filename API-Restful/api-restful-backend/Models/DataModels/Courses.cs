using System.ComponentModel.DataAnnotations;

namespace api_restful_backend.Models.DataModels
{
    public enum Level
    {
        Basic,
        Medium,
        Advanced,
        Expert
    }
    public class Courses : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public Level Level { get; set; } = Level.Basic;

        [Required]
        public ICollection<Categoría> Categories { get; set; } = new List<Categoría>();

        [Required]
        public Chapters Chapters { get; set; } = new Chapters();

        [Required]
        public ICollection<Students> Students { get; set; } = new List<Students>();
    }
}
