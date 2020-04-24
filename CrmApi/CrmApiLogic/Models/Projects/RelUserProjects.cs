using System;
namespace CrmApiLogic.Models.Projects
{
    public class RelUserProjects : BaseModel
    {
        public Guid ProjectId { get; set; }

        public Guid UserId { get; set; }

    }
}
