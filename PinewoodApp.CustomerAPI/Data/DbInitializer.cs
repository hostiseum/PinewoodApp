using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using PinewoodApp.CustomerAPI.Models;
using System.Text.Json;

namespace PinewoodApp.CustomerAPI.Data
{
    /// <summary>
    /// Seed data from seed.json
    /// </summary>
    public class DbInitializer
    {
        public static void Seed(AppDBContext context)
        {

            if (!context.Customers.Any())
            {

                Customer[] customers = JsonConvert.DeserializeObject<Customer[]>(File.ReadAllText(@"Data/seed.json"))!;

                context.AddRange(customers!);
                context.SaveChanges();

            }
        }
    }
}
