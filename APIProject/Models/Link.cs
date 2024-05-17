namespace APIProject.Models
{
    public class Link
    {
        public int LinkId { get; set; }
        public string Url { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public Interest Interest { get; set; }
        public int InterestId { get; set;}
    }
}
