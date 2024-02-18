using System.ComponentModel.DataAnnotations;

namespace api_restful_backend.Models.DataModels
{
    public class Chapters : BaseEntity
    {
        public int CourseId {get; set;}
        public virtual Courses Course { get; set;} = new Courses();
        [Required]
        public string List = string.Empty;
    }
}
