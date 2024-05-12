using APIProject.Data;
using APIProject.Handlers;
using APIProject.Repository;
using Microsoft.EntityFrameworkCore;


namespace APIProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

        
            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));


            builder.Services.AddScoped<IPersonHelper, PersonHelper>();
            builder.Services.AddScoped<IInterestHelper, InterestHelper>();


            
            var app = builder.Build();




            app.MapGet("/people/", PersonHandler.ListPeople);
            app.MapPost("/people", PersonHandler.AddPeople);
            app.MapPost("/interests", InterestHandler.AddInterest);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                 app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();

    

            app.Run();
        }
    }
}