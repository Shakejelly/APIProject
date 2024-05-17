using APIProject.Models.ViewModels;
using APIProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIProject.Handlers
{
    public class InterestHandler
    {
        public static IResult AddInterest([FromBody] InterestViewModel interestViewModel, IInterestHelper interestHelper)
        {
            try
            {
                interestHelper.AddInterest(interestViewModel);
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
        public static IResult ViewInterest(int id, IInterestHelper interestHelper)
        {
            try
            {
                return Results.Json(interestHelper.ViewInterest(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

    }
}
