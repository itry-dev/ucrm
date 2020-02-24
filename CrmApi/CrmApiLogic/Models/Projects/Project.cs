using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CrmApiLogic.Interfaces;

namespace CrmApiLogic.Models.Projects
{
    public class Project : BaseModel, IModel
    {
        public Project()
        {
        }

        [MaxLength(500, ErrorMessage = "Project name cannot be longer than 500 characters")]
        [Required(ErrorMessage ="Project name is mandatory")]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? HourlyRate { get; set; }

        [MaxLength(1000, ErrorMessage = "Notes cannot be long than 1000 characters")]
        public string AdditionalNotes { get; set; }

        [Required(ErrorMessage = "CustomerId cannot be null")]
        public Guid CustomerId { get; set; }

        public Customers.Customer Customer { get; set; }

    }
}
