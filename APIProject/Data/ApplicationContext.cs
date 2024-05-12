using APIProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


namespace APIProject.Data

{
    public class ApplicationContext : DbContext
    {
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonInterest> PersonInterests {get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) {}


    }
}
