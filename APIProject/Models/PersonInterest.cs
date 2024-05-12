using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProject.Models
{
    
    public class PersonInterest
    {
        [Key]
        public int Id { get; set; }
       

        public string? Link { get; set; }
        public int PersonId { get; set; }
        public virtual Person Persons { get; set; }
        public int InterstId { get; set; }
        public virtual Interest Interests { get; set; }

    }
}
