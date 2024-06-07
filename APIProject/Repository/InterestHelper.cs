using APIProject.Data;
using APIProject.Models.ViewModels;
using APIProject.Models;
using Microsoft.EntityFrameworkCore;
using APIProject.Models.Dto;
using System.Linq;

namespace APIProject.Repository
{
    public class InterestHelper : IInterestHelper
    {
        private readonly ApplicationContext _context;

        public InterestHelper(ApplicationContext context)
        {
            _context = context;
        }
        public void AddInterest(InterestDto interestDto)
        {
            var interest = new Interest
            {
                Title = interestDto.Title,
                Description = interestDto.Description,

            };

            _context.Interests.Add(interest);
            _context.SaveChanges();
        }

        public void AddLinkToInterest(int personId, int interestId, LinkDto linkDto)
        {
            // Making sure that if the it makes a new personInterest whenever you put in a link from a person to a interest. But if the person already is linked to the interest no new links will happen.
            var existingPersonInterest = _context.PersonInterests
                .FirstOrDefault(pi => pi.PersonId == personId && pi.InterestId == interestId);
                
            if (existingPersonInterest == null) { 
            var personInterest = new PersonInterest
            {
                PersonId = personId,
                InterestId = interestId,

            };
            _context.PersonInterests.Add(personInterest);
            }

            var link = new Link
            {
                InterestId = interestId,
                Url = linkDto.Url,
            };
            _context.Links.Add(link);
            _context.SaveChanges();
        }

        public List<InterestViewModel> ListInterests()
        {
            return _context.Interests
                .Include(p => p.PersonInterests)
                .Select(p => new InterestViewModel
                {
                    InterestId = p.InterestId,
                    Title = p.Title,
                    Description = p.Description,

                })
                .ToList();
        }

        public List<LinkViewModel> ListLinks(int id)
        {
            return _context.Links
                .Include(li => li.Interest)
                 .Where(li => li.InterestId == id)
                 .Select(li => new LinkViewModel
                 {
                     InterestId = li.InterestId,
                     Title = li.Interest.Title,
                     Url = li.Url,


                 })
            .ToList();

        }

    }
    
}
