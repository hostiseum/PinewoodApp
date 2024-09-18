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

            public AppDBContext() {
             
            }
            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                options.UseInMemoryDatabase(Configuration["Database"]!.ToString());
            }


            public DbSet<Customer> Customers { get; set; }
    }
}
