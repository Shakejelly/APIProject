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
        public DbSet<Link> Links { get; set; }
      

        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonInterest>()
                .HasKey(pi => new { pi.PersonId, pi.InterestId });


            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Person)
                .WithMany(p => p.PersonInterests)
                .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Interest)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestId);
        }
    }
}
