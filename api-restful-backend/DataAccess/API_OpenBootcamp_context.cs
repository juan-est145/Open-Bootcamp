using api_restful_backend.Models.DataModels;
using Microsoft.EntityFrameworkCore;


namespace api_restful_backend.DataAccess
{
    public class API_OpenBootcamp_context : DbContext
    {
        public API_OpenBootcamp_context(DbContextOptions<API_OpenBootcamp_context> options) : base(options) 
        {

        }

        //ToDo: Add DbSets (Tables of our Data base)
        public DbSet<Users>? Users { get; set; }
    }
}
