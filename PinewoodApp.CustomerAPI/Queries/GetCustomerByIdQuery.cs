using MediatR;
using PinewoodApp.CustomerAPI.Models;

namespace PinewoodApp.CustomerAPI.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; set; }
    }
}
