using api_restful_backend.Models.DataModels;

namespace api_restful_backend.Services
{
    public interface IStudentsService
    {
        IEnumerable<Students> GetStudentsWithCourses();
        IEnumerable<Students> GetStudentsWithNoCourses();
    }
}
