using APIProject.Models.Dto;
using APIProject.Models.ViewModels;
using APIProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIProject.Handlers
{
    public class InterestHandler
    {
        public static IResult AddInterest([FromBody] InterestDto interestDto, IInterestHelper interestHelper)
        {
            try
            {
                interestHelper.AddInterest(interestDto);
                return Results.StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        public static IResult ListInterests(IInterestHelper interestHelper)
        {
            try
            {
                return Results.Json(interestHelper.ListInterests());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static IResult AddLinkToInterest(int personId, int interestId, [FromBody] LinkDto linkDto, IInterestHelper interestHelper)
        {
            try
            {
                interestHelper.AddLinkToInterest(personId, interestId, linkDto);
                return Results.StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {

                return Results.Json(ex.Message);
            }
        }
        public static IResult ListLinks(int id, IInterestHelper interestHelper)
        {
            try
            {
                return Results.Json(interestHelper.ListLinks(id));
            }
            catch (Exception ex)
            {

                return Results.Json(ex.Message);
            }
        }
        

    }
}
