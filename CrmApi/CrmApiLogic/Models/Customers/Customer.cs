using System;
using System.ComponentModel.DataAnnotations;

namespace CrmApiLogic.Models.Customers
{
    public class Customer : BaseModel
    {
        public Customer()
        {
        }


        [MaxLength(500, ErrorMessage = "Company name cannot be longer than 500 characters")]
        [Required(ErrorMessage = "Company name is mandatory")]
        public string CompanyName { get; set; }

        [MaxLength(250, ErrorMessage = "Email cannot be longer than 250 characters")]
        public string Email { get; set; }

        [MaxLength(250, ErrorMessage = "City name cannot be longer than 250 characters")]
        public string City { get; set; }

        [MaxLength(20, ErrorMessage = "VAT cannot be longer than 20 characters")]
        public string VAT { get; set; }

        [MaxLength(250, ErrorMessage = "Country name cannot be longer than 250 characters")]
        public string Country { get; set; }

        [MaxLength(250, ErrorMessage = "Town name cannot be longer than 250 characters")]
        public string Town { get; set; }

        [MaxLength(50, ErrorMessage = "Phone number cannot be longer than 50 characters")]
        public string PhoneNumber { get; set; }

        [MaxLength(250, ErrorMessage = "CEO name cannot be longer than 250 characters")]
        public string CEOName { get; set; }

    }
}
