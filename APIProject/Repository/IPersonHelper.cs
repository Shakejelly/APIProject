using APIProject.Data;
using APIProject.Models;
using APIProject.Models.Dto;
using APIProject.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Repository
{
    public interface IPersonHelper
{
    public List<PersonViewModel> ListPeople();
    public PersonViewModel ViewPeople(int id);
    public void AddPerson(PersonDto personDto);
}
public class PersonHelper : IPersonHelper
{
    private ApplicationContext _context;
    public PersonHelper(ApplicationContext context)
    {
        _context = context;
    }

    public void AddPerson(PersonDto personDto)
    {
        Person person = new Person()
        {
            FirstName = personDto.FirstName,
            LastName = personDto.LastName,
            Age = personDto.Age,
        };
        _context.Persons.Add(person);
        _context.SaveChanges();
    }

    public List<PersonViewModel> ListPeople()
    {
        var result = _context.Persons
         .Select(p => new PersonViewModel()
         {
             FirstName = p.FirstName,
             LastName = p.LastName,
             Age = p.Age,
             PhoneNumber = p.PhoneNumber
         }).ToList();

        return result;
    }

    public PersonViewModel ViewPeople(int id)
    {
        Person entity = _context.Persons
         .Where(p => p.PersonId == id)
        .Include(p => p.PersonInterests)
        .SingleOrDefault();

        if (entity == null)

            throw new Exception("Person not found.");

        PersonViewModel result = new PersonViewModel()
        {
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Age = entity.Age,
            Interests = entity.PersonInterests.Select(pi => new InterestViewModel
            {
                Titel = pi.Interests.Titel,
                Description = pi.Interests.Description,
            })
            .ToArray()

    }; return result;
        }

    }
}
