using Microsoft.EntityFrameworkCore;
namespace APIProject.Data

{
    public class ApplicationContext : DbContext
    {


        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) { }
    }
}
