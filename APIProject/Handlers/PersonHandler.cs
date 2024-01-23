using APIProject.Data;
using APIProject.Models;
using APIProject.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Handlers
{
    public class PersonHandler
    {
        public static IResult ListPeople(ApplicationContext context)
        {
            PersonViewModel[] result = context.Persons
                 .Select(p => new PersonViewModel()
                 {
                     FirstName = p.FirstName,
                     LastName = p.LastName,
                     Age = p.Age,
                 }).ToArray();
            return Results.Json(result);
        }

        public static IResult ViewPeople(ApplicationContext context, int id)
        {
            Person entity = context.Persons
                .Where(p => p.PersonId == id)
                .Include(p => p.Interests)
                .SingleOrDefault();

            if (entity == null)
            {
                return Results.NotFound();
            }
            PersonViewModel result = new PersonViewModel()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Interests = entity.Interests.Select(i => new InterestViewModel()
                {
                    Titel = i.Titel,
                    Description = i.Description,
                })
                .ToArray()

            };
            return Results.Json(result);
        }

    }
}
