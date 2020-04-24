using System;
namespace CrmApiLogic.Models.Projects
{
    public class RelPrjectWorkedHours : BaseModel
    {
        public Guid WorkedHoursId { get; set; }

        public Guid ProjectId { get; set; }
    }
}
