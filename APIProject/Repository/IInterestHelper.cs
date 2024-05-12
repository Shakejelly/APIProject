using APIProject.Data;
using APIProject.Models;
using APIProject.Models.Dto;

namespace APIProject.Repository
{
    public interface IInterestHelper
    {
        public void AddInterest(InterestDto interestDto);

    }
    public class InterestHelper : IInterestHelper
    {
        private Data.ApplicationContext _context;
        public InterestHelper(Data.ApplicationContext context)
        {
            _context = context;
        }

        public void AddInterest(InterestDto interestDto)
        {
            Interest interest = new Interest()
            {
                Titel = interestDto.Titel,
                Description = interestDto.Description,
            };
            _context.Interests.Add(interest);
            _context.SaveChanges();
        }
    }
}
