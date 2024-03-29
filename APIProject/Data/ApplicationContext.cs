﻿using APIProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


namespace APIProject.Data

{
    public class ApplicationContext : DbContext
    {
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Link> Links {get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) { }
    }
}
