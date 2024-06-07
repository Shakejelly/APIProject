using APIProject.Models.Dto;
using APIProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace APIProject.Repository

{
    public interface IPersonHelper
    {
        List<PersonDto> ListPeople();
        void AddPerson(PersonDto personDto);
        List<PersonInterestViewModel> GetPersonInterests(int id);
        void AddPersonInterest(int personId, int interestId, IPersonHelper personHelper);
        List<PersonLinksViewModel>LinksConnectedToPersons(int id, IPersonHelper personHelper);

    }
}
