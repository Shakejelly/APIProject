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
        public static IResult GetPersonInterests(int id, IPersonHelper personHelper)
        {
            try
            {
                return Results.Json(personHelper.GetPersonInterests(id));
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

        public static IResult AddPersonInterest(int id, int interestId, string url, IPersonHelper personHelper)
        {
            try
            {
                personHelper.AddPersonInterest(id, interestId, url, personHelper);
                return Results.StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
