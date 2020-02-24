using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrmApiLogic.Models.Projects
{
    public class WorkedHour : BaseModel
    {
        public WorkedHour()
        {
        }


        [Required(ErrorMessage = "Hours cannot be null")]
        public double Hours { get; set; }

        private DateTime _date;
        [Required(ErrorMessage = "Date cannot be null")]
        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value.Date;
            }
        }

        public decimal? HourlyRate { get; set; }

        public bool AtCustomerOffice { get; set; }

        [MaxLength(1000, ErrorMessage = "Notes cannot be long than 1000 characters")]
        public string AdditionalNotes { get; set; }

        [Required(ErrorMessage = "ProjectId cannot be null")]
        public Guid ProjectId { get; set; }

        public Projects.Project Project { get; set; }



    }
}
