using api_restful_backend.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;

namespace api_restful_backend.DataAccess
{
    public class API_OpenBootcamp_context : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;


        public API_OpenBootcamp_context(DbContextOptions<API_OpenBootcamp_context> options, ILoggerFactory loggerFactory) : base(options) 
        {
            _loggerFactory = loggerFactory;
        }

        //ToDo: Add DbSets (Tables of our Data base)
        public DbSet<Users>? Users { get; set; }
        public DbSet<Courses>? Courses { get; set; }
        public DbSet<Categoría>? Categoría { get; set; }
        public DbSet<Students>? Students { get; set; }
        public DbSet<Chapters>? Chapters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = _loggerFactory.CreateLogger<API_OpenBootcamp_context>();
            //optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name}));
            //optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information).EnableSensitiveDataLogging().EnableDetailedErrors();

        }
    }
}
