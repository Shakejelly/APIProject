namespace APIProject.Models.ViewModels
{
    public class PersonViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public InterestViewModel[] Interests { get; set; }
    
    }
}
