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
        public DbSet<Link> Links {  get; set; }  

        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonInterest>()
                .HasKey(pi => new { pi.PersonId, pi.InterestId });

            modelBuilder.Entity<Link>()
                .HasOne(l => l.Person)
                .WithMany(p => p.Links)
                .HasForeignKey(l => l.PersonId);

            modelBuilder.Entity<Link>()
                .HasOne(l => l.Interest)
                .WithMany(i => i.Links)
                .HasForeignKey(l => l.InterestId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
