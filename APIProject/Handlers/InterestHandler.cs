using APIProject.Models.Dto;
using APIProject.Repository;
using System.Net;

namespace APIProject.Handlers
{
    public class InterestHandler
    {
        public static IResult AddInterest(InterestDto interestDto, IInterestHelper interestHelper)
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
     
    }
}
