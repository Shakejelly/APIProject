using APIProject.Data;
using APIProject.Models.ViewModels;
using APIProject.Models;
using Microsoft.EntityFrameworkCore;
using APIProject.Models.Dto;

namespace APIProject.Repository
{
    public class InterestHelper : IInterestHelper
    {
    private readonly ApplicationContext _context;

    public InterestHelper(ApplicationContext context)
    {
        _context = context;
    }
        public void AddInterest(InterestViewModel interestViewModel)
        {
            var interest = new Interest
            {
                Title = interestViewModel.Title,
                Description = interestViewModel.Description,
                
            };

            _context.Interests.Add(interest);
            _context.SaveChanges();
        }

        public List<InterestDto> ListInterests()
        {
            return _context.Interests
                .Include(p => p.PersonInterests)
                .Select(p => new InterestDto
                {
                    InterestId = p.InterestId,
                    Title = p.Title,
                    Description = p.Description,

                })
                .ToList();
        }

        public InterestDto ViewInterest(int id)
        {
            var interest = _context.Interests
                .Include(i => i.PersonInterests)
                .Where(i => i.InterestId == id)
                .Select(i => new InterestDto
                {
                    InterestId = i.InterestId,
                    Title = i.Title,
                    Description = i.Description
                })
                .FirstOrDefault();

            return interest;
        }
    }

    
}
