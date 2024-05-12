using System.ComponentModel.DataAnnotations;
using APIProject.Models;

namespace APIProject.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }

     


        
        public virtual ICollection<PersonInterest> PersonInterests { get; set; }

    }
}
