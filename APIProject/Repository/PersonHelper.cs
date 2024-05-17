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

        public void AddPerson(PersonViewModel personViewModel)
        {
            var person = new Person
            {
                FirstName = personViewModel.FirstName,
                LastName = personViewModel.LastName,
                PhoneNumber = personViewModel.PhoneNumber,
                Age = personViewModel.Age
            };

            _context.Persons.Add(person);
            SaveChangesWithDetailedLogging();
        }

        public void AddPersonInterest(int personId, int interestId, string url, IPersonHelper personHelper)
        {
            var personInterest = new PersonInterest
            {
                PersonId = personId,
                InterestId = interestId,
                Url = url
            };

            _context.PersonInterests.Add(personInterest);
            SaveChangesWithDetailedLogging();
        }
        public List<InterestDto> GetPersonInterests(int id)
        {
            return _context.PersonInterests
                .Where(pi => pi.PersonId == id)
                .Include(pi => pi.Interest)
                .Select(pi => new InterestDto
                {
                    InterestId = pi.Interest.InterestId,
                    Title = pi.Interest.Title,
                    Description = pi.Interest.Description,
                    
                })
                .ToList();
        }

        public List<PersonDto> ListPeople()
        {
            return _context.Persons
                .Include(p => p.PersonInterests)


                .Select(p => new PersonDto
                {
                    PersonId = p.PersonId,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PhoneNumber = p.PhoneNumber,
                    Age = p.Age,

                })
                .ToList();
        }

        public PersonDto ViewPeopleInterest(int id)
        {
            var person = _context.Persons
                .Include(p => p.PersonInterests)
                .ThenInclude(p => p.Interest)
                .Where(p => p.PersonId == id)
                .Select(p => new PersonDto
                {
                    PersonId = p.PersonId,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PhoneNumber = p.PhoneNumber,
                    Interests = p.PersonInterests.Select(pi => new InterestDto
                    {
                        InterestId = pi.Interest.InterestId,
                        Title = pi.Interest.Title,
                        Description = pi.Interest.Description,
                        
                    }).ToList()
                    

                })
                .FirstOrDefault();

            return person;
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
