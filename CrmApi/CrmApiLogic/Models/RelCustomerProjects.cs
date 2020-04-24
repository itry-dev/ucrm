using System;
namespace CrmApiLogic.Models
{
    public class RelCustomerProjects : BaseModel
    {
        public Guid CustomerId { get; set; }

        public Guid ProjectId { get; set; }
    }
}
