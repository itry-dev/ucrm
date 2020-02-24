using System;
namespace CrmApiLogic.Specifications.Project
{
    public class GetWorkedHours : BaseSpecification<CrmApiLogic.Models.Projects.WorkedHour>
    {
        public GetWorkedHours(Guid id)
        {
            Criteria = c => c.Id == id;
            IncludeStrings.Add($"{nameof(CrmApiLogic.Models.Projects.Project)}.{nameof(CrmApiLogic.Models.Customers.Customer)}");
        }
    }
}
