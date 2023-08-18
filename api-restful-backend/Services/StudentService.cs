using api_restful_backend.Models.DataModels;

namespace api_restful_backend.Services
{
    public class StudentService : IStudentsService
    {
        public IEnumerable<Students> GetStudentsWithCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Students> GetStudentsWithNoCourses()
        {
            throw new NotImplementedException();
        }
    }
}
