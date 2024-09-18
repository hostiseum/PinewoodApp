using MediatR;
using PinewoodApp.CustomerAPI.Commands;
using PinewoodApp.CustomerAPI.Models;
using PinewoodApp.CustomerAPI.Repositories;

namespace PinewoodApp.CustomerAPI.Handlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerHandler(ICustomerRepository CustomerRepository)
        {
            _customerRepository = CustomerRepository;
        }
        public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {

            var customerDetails = await _customerRepository.GetCustomerByIdAsync(command.Id);
            if (customerDetails == null)
                return default;


            customerDetails.FirstName = command.FirstName;
            customerDetails.LastName = command.LastName;
            customerDetails.Email = command.Email;
            customerDetails.Country = command.Country;
            customerDetails.Phone = command.Phone;
            customerDetails.PostalCode = command.PostalCode;
            customerDetails.City = command.City;
            customerDetails.Address = command.Address;
            

            return await _customerRepository.UpdateCustomerAsync(customerDetails);
        }
    }
}

