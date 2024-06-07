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

        public static IResult AddPerson([FromBody] PersonDto personDto, IPersonHelper personHelper)
        {
            try
            {
                personHelper.AddPerson(personDto);
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
                personHelper.AddPersonInterest(id, interestId, personHelper);
                return Results.StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        public static IResult LinksConnectedToPersons(int personId, IPersonHelper personHelper)
        {
            try
            {
                return Results.Json(personHelper.LinksConnectedToPersons(personId, personHelper));
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message); 
            }
        }
    }
}
