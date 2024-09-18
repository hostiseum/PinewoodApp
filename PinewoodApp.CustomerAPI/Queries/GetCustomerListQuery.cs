using MediatR;
using PinewoodApp.CustomerAPI.Models;

namespace PinewoodApp.CustomerAPI.Queries
{
    public class GetCustomerListQuery : IRequest<List<Customer>>
    {
    }
}
