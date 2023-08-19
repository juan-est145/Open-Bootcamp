//1. Usings to work with EntityFramework
using Microsoft.EntityFrameworkCore;
using api_restful_backend.DataAccess;
using api_restful_backend.Services;

var builder = WebApplication.CreateBuilder(args);


//2. Connection with SQL Server Express
const string CONNECTIONNAME = "API_OpenBootcampDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//3. Add Context
builder.Services.AddDbContext<API_OpenBootcamp_context>(options => options.UseSqlServer(connectionString));


//7. Add Service of JWT Autorization
//builder.Services.AddJwtTokenServices(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

//4. Add Custom services (folder services)
builder.Services.AddScoped<IStudentsService, StudentService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//5. CORS Configuration
builder.Services.AddCors(options => 
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//6. Tell app to use CORS
app.UseCors("CorsPolicy");

app.Run();
