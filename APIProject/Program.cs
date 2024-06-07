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
            app.MapGet("/alllinksfrominterest", (int id, IInterestHelper interestHelper) => InterestHandler.ListLinks(id, interestHelper));
            app.MapGet("/allinterests", (IInterestHelper interestHelper) => InterestHandler.ListInterests(interestHelper));
            app.MapGet("/personinterests", (int id, IPersonHelper personHelper) => PersonHandler.GetPersonInterests(id, personHelper));
            app.MapGet("/listlinksconnectedtopersons", (int personId, IPersonHelper personHelper) => PersonHandler.LinksConnectedToPersons(personId, personHelper));

            app.MapPost("/addpeople", (PersonDto personDto, IPersonHelper personHelper) => PersonHandler.AddPerson(personDto, personHelper));
            app.MapPost("/addinterest", (InterestDto interestDto, IInterestHelper interestHelper) => InterestHandler.AddInterest(interestDto, interestHelper));
            app.MapPost("/addpersoninterest", (int id, int interestId, IPersonHelper personHelper) => PersonHandler.AddPersonInterest(id, interestId, personHelper));
            app.MapPost("/AddLinkToInterest", (int personId, int interestId, LinkDto linkDto, IInterestHelper interestHelper) => InterestHandler.AddLinkToInterest(personId, interestId, linkDto, interestHelper));
            

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