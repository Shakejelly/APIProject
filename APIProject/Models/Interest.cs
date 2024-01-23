using System.ComponentModel.DataAnnotations;

namespace APIProject.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }

     


        public virtual Person Persons { get; set; }

    }
}
