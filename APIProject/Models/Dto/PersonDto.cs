
namespace APIProject.Models.Dto
{
    public class PersonDto
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public List<InterestDto> Interests { get; internal set; }
    }
}
