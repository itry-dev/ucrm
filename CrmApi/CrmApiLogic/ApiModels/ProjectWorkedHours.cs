using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrmApiLogic.ApiModels
{
    [NotMapped]
    public class ProjectWorkedHours
    {
        public string CompanyName { get; set; }

        public string ProjectId { get; set; }

        public string ProjectName { get; set; }

        public double Hours { get; set; }

        public double TotalAmount { get; set; }
    }
}
