using System;
namespace CrmApiLogic.ApiModels
{
    public class Report
    {
        public string CompanyName { get; set; }

        public string ProjectId { get; set; }

        public string ProjectName { get; set; }

        public double Hours { get; set; }

        public double TotalAmount { get; set; }
    }
}
