using System.ComponentModel.DataAnnotations.Schema;

namespace APIProject.Models
{
    [Table("Link")]
    public class Link
    {
        public int Id { get; set; }
        public string? WebLink { get; set; }

        public virtual Person Persons { get; set; }
        public virtual Interest Interest { get; set; }
    }
}
