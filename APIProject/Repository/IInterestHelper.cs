using APIProject.Models.Dto;
using APIProject.Models.ViewModels;
namespace APIProject.Repository
{
    public interface IInterestHelper
    {
        void AddInterest(InterestViewModel interestViewModel);
        List<InterestDto> ListInterests();
        InterestDto ViewInterest(int id);
    }
}
