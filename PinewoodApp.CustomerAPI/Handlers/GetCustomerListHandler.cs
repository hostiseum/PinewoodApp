using MediatR;
using PinewoodApp.CustomerAPI.Models;
using PinewoodApp.CustomerAPI.Queries;
using PinewoodApp.CustomerAPI.Repositories;

namespace PinewoodApp.CustomerAPI.Handlers
{
    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, List<Customer>>
    {
        public ICustomerRepository _customerRepository;
        public GetCustomerListHandler(ICustomerRepository customerRepository) {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerListAsync();
        }
    }
}
