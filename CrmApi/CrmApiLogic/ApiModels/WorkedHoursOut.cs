using System;
using System.Collections.Generic;
using CrmApiLogic.Models.Customers;
using CrmApiLogic.Models.Projects;

namespace CrmApiLogic.ApiModels
{
    public class WorkedHoursOut
    {
        public Customer Customer { get; set; }

        public List<WorkedHour> WorkedHours { get; set; }
    }
}
