using APIProject.Data;
using APIProject.Models;
using APIProject.Models.Dto;
using APIProject.Models.ViewModels;
using APIProject.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace APIProject.Handlers
{
    public class PersonHandler
    {
        public static IResult ListPeople(IPersonHelper personHelper)
        {
            try
            {
                return Results.Json(personHelper.ListPeople);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }            
            
   
            
        }

        public static IResult ViewPeople(int id, IPersonHelper personHelper)
        {
            try
            {
              return Results.Json(personHelper.ViewPeople(id));
            }
              catch (Exception ex) 
            {
              return Results.Problem(ex.Message);
            }
            
        }
        public static IResult AddPeople(PersonDto personDto, IPersonHelper personHelper)
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

    }
}
