using MediatR;
using PinewoodApp.CustomerAPI.Commands;
using PinewoodApp.CustomerAPI.Models;
using PinewoodApp.CustomerAPI.Repositories;

namespace PinewoodApp.CustomerAPI.Handlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerHandler(ICustomerRepository CustomerRepository)
        {
            _customerRepository = CustomerRepository;
        }
        public async Task<int> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {

            var customerDetails = await _customerRepository.GetCustomerByIdAsync(command.Id);
            if (customerDetails == null)
                return default;

            return await _customerRepository.DeleteCustomerAsync(command.Id);
        }
    }
}

