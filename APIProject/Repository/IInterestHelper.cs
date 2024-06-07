using APIProject.Models.Dto;
using APIProject.Models.ViewModels;
namespace APIProject.Repository
{
    public interface IInterestHelper
    {
        void AddInterest(InterestDto interestDto);
        List<InterestViewModel> ListInterests();
        void AddLinkToInterest(int personId, int interestId, LinkDto linkDto);
        List<LinkViewModel> ListLinks(int id);

    }
}
