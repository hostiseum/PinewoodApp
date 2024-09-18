using MediatR;
using PinewoodApp.CustomerAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PinewoodApp.CustomerAPI.Commands
{
    public class DeleteCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
     

        public DeleteCustomerCommand(int id)
        {
            Id = id;    
          
        }
    }
}
