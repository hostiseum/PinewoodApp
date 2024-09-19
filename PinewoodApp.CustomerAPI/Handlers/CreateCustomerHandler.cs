using MediatR;
using PinewoodApp.CustomerAPI.Commands;
using PinewoodApp.CustomerAPI.Models;
using PinewoodApp.CustomerAPI.Repositories;

namespace PinewoodApp.CustomerAPI.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository CustomerRepository)
        {
            _customerRepository = CustomerRepository;
        }
        public async Task<Customer> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customerDetails = new Customer()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Country = command.Country,
                Phone = command.Phone,
                PostalCode = command.PostalCode,
                City = command.City,
            };

            return await _customerRepository.AddCustomerAsync(customerDetails);
        }
    }
}

