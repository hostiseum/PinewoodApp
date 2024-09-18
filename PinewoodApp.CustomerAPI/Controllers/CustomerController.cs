using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PinewoodApp.CustomerAPI.Commands;
using PinewoodApp.CustomerAPI.Models;
using PinewoodApp.CustomerAPI.Queries;

namespace PinewoodApp.CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMediator _mediator;

        public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetCustomerListAsync")]
       
        public async Task<IEnumerable<Customer>> GetCustomerListAsync()
        {
            var customers = await _mediator.Send(new GetCustomerListQuery());

            return customers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerByIdAsync(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery() { Id = id});

            if (customer == default)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost]
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            var customerDetail = await _mediator.Send(new CreateCustomerCommand(
               customer.FirstName,
               customer.LastName,
               customer.Email,
               customer.Phone,
               customer.Address,
               customer.City,
               customer.PostalCode,
               customer.Country));
            return customerDetail;
        }

        [HttpPut]
        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            var customerUpdated = await _mediator.Send(new UpdateCustomerCommand(
               customer.Id,
               customer.FirstName,
               customer.LastName,
               customer.Email,
               customer.Phone,
               customer.Address,
               customer.City,
               customer.PostalCode,
               customer.Country));
            return customerUpdated;
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteCustomerAsync(int id)
        {
            var customerUpdated = await _mediator.Send(new DeleteCustomerCommand(id));
            return customerUpdated;
        }
    }
}
