using System;
namespace CrmApiLogic.Models.Customers
{
    public class RelUserCustomers : BaseModel
    {
        public Guid ProjectId { get; set; }

        public Guid UserId { get; set; }
    }
}
