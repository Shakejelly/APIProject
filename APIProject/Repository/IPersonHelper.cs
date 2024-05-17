using APIProject.Models.Dto;
using APIProject.Models.ViewModels;
namespace APIProject.Repository

{
    public interface IPersonHelper
    {
        List<PersonDto> ListPeople();
        PersonDto ViewPeopleInterest(int id);
        void AddPerson(PersonViewModel personViewModel);
        List<InterestDto> GetPersonInterests(int id);
        void AddPersonInterest(int personId, int interestId, string url, IPersonHelper personHelper);
        
    }
}
