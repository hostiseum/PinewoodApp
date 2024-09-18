using PinewoodApp.CustomerAPI.Models;

namespace PinewoodApp.CustomerAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<int> DeleteCustomerAsync(int Id);
        Task<Customer> GetCustomerByIdAsync(int Id);
        Task<List<Customer>> GetCustomerListAsync();
        Task<int> UpdateCustomerAsync(Customer customer);
    }
}