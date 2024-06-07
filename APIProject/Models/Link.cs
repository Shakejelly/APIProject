using System.ComponentModel.DataAnnotations;

namespace APIProject.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public Interest Interest { get; set; }
        public int InterestId { get; set; }
        public string Url { get; set; }
        
    }
}
