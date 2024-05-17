using APIProject.Models.Dto;
using APIProject.Models.ViewModels;
using APIProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIProject.Handlers
{
    public class PersonHandler
    {
        public static IResult ListPeople(IPersonHelper personHelper)
        {
            try
            {
                return Results.Json(personHelper.ListPeople());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }



        }
        public static IResult GetPersonLinks(int id, IPersonHelper personHelper)
        {
            try
            {
                return Results.Json(personHelper.GetPersonLinks(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static IResult ViewPeopleInterest(int id, IPersonHelper personHelper)
        {
            try
            {
                return Results.Json(personHelper.ViewPeopleInterest(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
        public static IResult AddPerson([FromBody] PersonViewModel personViewModel, IPersonHelper personHelper)
        {
            try
            {
                personHelper.AddPerson(personViewModel);
                return Results.StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static IResult AddPersonInterest(int id, int interestId, IPersonHelper personHelper)
        {
            try
            {
                personHelper.AddPersonInterest(id, interestId);
                return Results.StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        public static IResult AddPersonLink(int id, [FromBody] LinkViewModel linkViewModel, IPersonHelper personHelper)
        {
            try
            {
                personHelper.AddPersonLink(id, linkViewModel);
                return Results.StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
 


    }
}
