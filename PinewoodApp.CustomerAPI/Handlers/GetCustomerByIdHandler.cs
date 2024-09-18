using MediatR;
using PinewoodApp.CustomerAPI.Models;
using PinewoodApp.CustomerAPI.Queries;
using PinewoodApp.CustomerAPI.Repositories;

namespace PinewoodApp.CustomerAPI.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        public ICustomerRepository _customerRepository;
        public GetCustomerByIdHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerByIdAsync(request.Id);
        }
    }
}
