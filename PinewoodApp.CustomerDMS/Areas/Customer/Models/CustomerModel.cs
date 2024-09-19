using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PinewoodApp.CustomerDMS.Areas.Customer.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage ="Please enter First Name.")]
        [DataType(DataType.Text)]
        public  string FirstName { get; set; } =string.Empty;
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter Last Name.")]
        public string LastName { get; set; }=string.Empty;
        
        [DisplayName("Email")]
        [EmailAddress]
        public string? Email { get; set; } 

        public string? Phone { get; set; }
        
        public string? City { get; set; }    
      
        
        [DisplayName("Postal Code")]
        [Required(ErrorMessage = "Please enter Postal Code.")]
        public string PostalCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter Country.")]
        public string Country { get; set; } = string.Empty;


    }
}
