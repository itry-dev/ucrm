using System;
using CrmApiLogic.Models.Customers;

namespace CrmApiLogic.Specifications.Customer
{
    public class FindCustomer : BaseSpecification<CrmApiLogic.Models.Customers.Customer>
    {
        public FindCustomer(string q, int page=0)
        {
            if (!string.IsNullOrWhiteSpace(q)) Criteria = c => c.CompanyName.Contains(q);
            ApplyPaging(page, 20);
            
        }

        
    }
}
