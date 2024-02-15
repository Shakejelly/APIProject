using APIProject.Data;
using APIProject.Handlers;
using Microsoft.EntityFrameworkCore;

namespace APIProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string conntectionString = builder.Configuration.GetConnectionString("ApplicationContext");
            builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(conntectionString));

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.MapGet("/people/{search?}", PersonHandler.ListPeople);
            app.MapPost("/people", PersonHandler.AddPeople);
            app.MapPost("/interests", InterestHandler.AddInterest);

            app.Run();
        }
    }
}