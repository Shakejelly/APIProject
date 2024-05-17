using APIProject.Models.Dto;
using APIProject.Models.ViewModels;
namespace APIProject.Repository

{
    public interface IPersonHelper
    {
        List<PersonDto> ListPeople();
        PersonDto ViewPeopleInterest(int id);
        void AddPerson(PersonViewModel personViewModel);
        
        List<LinkDto> GetPersonLinks(int id);
        void AddPersonInterest(int personId, int interestId);
        void AddPersonLink(int personId, LinkViewModel linkViewModel);
    }
}
