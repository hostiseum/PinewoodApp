using MediatR;
using PinewoodApp.CustomerAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PinewoodApp.CustomerAPI.Commands
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public UpdateCustomerCommand(int id, string firstName, string lastName, string? email, 
                                     string? phone, string? city, 
                                     string postalCode, string country)
        {
            Id = id;    
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            City = city;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
