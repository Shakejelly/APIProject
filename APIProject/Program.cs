using APIProject.Data;
using APIProject.Handlers;
using APIProject.Models.Dto;
using APIProject.Models.ViewModels;
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



            app.MapGet("/allpeople", (IPersonHelper personHelper) => PersonHandler.ListPeople(personHelper));
            app.MapGet("/viewpeopleinterest/{id}", (int id, IPersonHelper personHelper) => PersonHandler.ViewPeopleInterest(id, personHelper));
            app.MapPost("/addpeople", (PersonViewModel personViewModel, IPersonHelper personHelper) => PersonHandler.AddPerson(personViewModel, personHelper));
            app.MapPost("/addinterest", (InterestViewModel interestViewModel, IInterestHelper interestHelper) => InterestHandler.AddInterest(interestViewModel, interestHelper));
            app.MapGet("/allinterests", (IInterestHelper interestHelper) => InterestHandler.ListInterests(interestHelper));
            app.MapGet("/viewinterest/{id}", (int id, IInterestHelper interestHelper) => InterestHandler.ViewInterest(id, interestHelper));
            app.MapPost("/addpersoninterest/{id}", (int id, int interestId, IPersonHelper personHelper) => PersonHandler.AddPersonInterest(id, interestId, personHelper));
            app.MapGet("/links{id}", (int id, IPersonHelper personHelper) => PersonHandler.GetPersonLinks(id, personHelper));
            app.MapPost("/addlink/{id}", (int id, LinkViewModel linkViewModel, IPersonHelper personHelper) => PersonHandler.AddPersonLink(id, linkViewModel, personHelper));

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