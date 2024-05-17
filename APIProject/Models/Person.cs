using System.ComponentModel.DataAnnotations;

namespace APIProject.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }

       
        public virtual ICollection<PersonInterest> PersonInterests { get; set; }
        

    }
}
