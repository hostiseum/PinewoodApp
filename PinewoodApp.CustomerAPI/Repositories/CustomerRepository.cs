using Microsoft.EntityFrameworkCore;
using PinewoodApp.CustomerAPI.Data;
using PinewoodApp.CustomerAPI.Models;

namespace PinewoodApp.CustomerAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDBContext _dbContext;
        public CustomerRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            var result = _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteCustomerAsync(int Id)
        {
            var filteredData = _dbContext.Customers.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Customers.Remove(filteredData!);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int Id)
        {
            return await _dbContext.Customers.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Customer>> GetCustomerListAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
