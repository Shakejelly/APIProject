using System.ComponentModel.DataAnnotations;
using APIProject.Models;

namespace APIProject.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }

     


        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<Link> Links { get; set; }

    }
}
