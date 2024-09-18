using Microsoft.EntityFrameworkCore;
using PinewoodApp.CustomerAPI.Helpers;
using PinewoodApp.CustomerAPI.Models;

namespace PinewoodApp.CustomerAPI.Data
{
    public class AppDBContext:DbContext
    {
        
            protected readonly IConfiguration Configuration;

            public AppDBContext(IConfiguration configuration)
            {
                Configuration = configuration;
            }
            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                options.UseInMemoryDatabase(Configuration["Database"]!.ToString());
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            //Load Data
            //JsonHelper.Deserialize<Customer>(Configuration["SeedFilePath"]!.ToString());
                //modelBuilder.Entity<Customer>().HasData(
                //    new Author
                //    {
                //        AuthorId = 1,
                //        FirstName = "William",
                //        LastName = "Shakespeare"
                //    }
                //);
            }

        public DbSet<Customer> Customers { get; set; }
    }
}
