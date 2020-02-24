using System;

namespace CrmApiLogic.Specifications.Project
{
    public class FindProject : BaseSpecification<CrmApiLogic.Models.Projects.Project>
    {
        public FindProject(string q, int page=0)
        {
            if (!string.IsNullOrWhiteSpace(q)) Criteria = c => c.Name.Contains(q) || c.Customer.CompanyName.Contains(q);
            ApplyOrderBy(o => o.Customer.CompanyName);
            IncludeStrings.Add($"{nameof(CrmApiLogic.Models.Projects.Project.Customer)}");
            if (page>0) ApplyPaging(page, 20);
        }

        public FindProject(Guid id)
        {
            Criteria = c => c.Id == id;
            IncludeStrings.Add($"{nameof(CrmApiLogic.Models.Projects.Project.Customer)}");
        }

    }
}
