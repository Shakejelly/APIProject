using APIProject.Data;
using APIProject.Models;
using APIProject.Models.Dto;
using APIProject.Models.ViewModels;
using APIProject.Repository;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Repository
{
    public class PersonHelper : IPersonHelper
    {
        private readonly ApplicationContext _context;

        public PersonHelper(ApplicationContext context)
        {
            _context = context;
        }

        public void AddPerson(PersonDto personDto)
        {
            var person = new Person
            {
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                PhoneNumber = personDto.PhoneNumber,
                Age = personDto.Age
            };

            _context.Persons.Add(person);
            SaveChangesWithDetailedLogging();
        }

        public void AddPersonInterest(int personId, int interestId, IPersonHelper personHelper)
        {
            var personInterest = new PersonInterest
            {
                PersonId = personId,
                InterestId = interestId,

            };

            _context.PersonInterests.Add(personInterest);
            SaveChangesWithDetailedLogging();
        }
        public List<PersonInterestViewModel> GetPersonInterests(int id)
        {
            return _context.PersonInterests
                .Where(pi => pi.PersonId == id)
                .Include(pi => pi.Interest)
                .Select(pi => new PersonInterestViewModel
                {
                    Name = pi.Person.FirstName + " " + pi.Person.LastName,
                    Title = pi.Interest.Title,
                    Description = pi.Interest.Description,

                })
                .ToList();
        }

        public List<PersonLinksViewModel> LinksConnectedToPersons(int personId, IPersonHelper personHelper)
        {
            var personLinks = _context.PersonInterests
                .Where(pi => pi.PersonId == personId)
                .Include(pi => pi.Interest)
                .ThenInclude(i => i.Links)
                .Select(pi => new PersonLinksViewModel
                {
                    PersonId = pi.PersonId,
                    Urls = pi.Interest.Links
                        .Where(link => !string.IsNullOrEmpty(link.Url))
                        .Select(link => link.Url)
                        .ToList()
                })
                .ToList();

            return personLinks;
        }
    

        public List<PersonDto> ListPeople()
        {
            return _context.Persons
                .Include(p => p.PersonInterests)


                .Select(p => new PersonDto
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PhoneNumber = p.PhoneNumber,
                    Age = p.Age,

                })
                .ToList();
        }

       
        private void SaveChangesWithDetailedLogging()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var errorMessage = "An error occurred while saving the entity changes.";
                if (ex.InnerException != null)
                {
                    errorMessage += $" Inner exception: {ex.InnerException.Message}";
                }
                throw new Exception(errorMessage, ex);
            }
        }
    }
}
