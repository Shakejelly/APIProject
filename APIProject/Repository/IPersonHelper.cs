using APIProject.Data;
using APIProject.Models;
using APIProject.Models.Dto;
using APIProject.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Repository
{
    public interface IPersonHelper
    {
        public PersonViewModel[] ListPeople();
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

        public PersonViewModel[] ListPeople()
        {
            PersonViewModel[] result = _context.Persons
         .Select(p => new PersonViewModel()
         {
             FirstName = p.FirstName,
             LastName = p.LastName,
             Age = p.Age,
         }).ToArray();
            return result;
        }

        public PersonViewModel ViewPeople(int id)
        {
            Person entity = _context.Persons
             .Where(p => p.PersonId == id)
            .Include(p => p.Interests)
            .SingleOrDefault();

            if (entity == null)
            
                throw new Exception();
            
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

            }; return result;
        }

    }
}
