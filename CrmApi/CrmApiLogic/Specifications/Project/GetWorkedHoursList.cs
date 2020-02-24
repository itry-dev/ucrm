using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CrmApiLogic.Specifications.Project
{
    public class GetWorkedHoursList : BaseSpecification<CrmApiLogic.Models.Projects.WorkedHour>
    {
        public GetWorkedHoursList(int year) : this(null, year, 0, 0) { }

        public GetWorkedHoursList(int year, int month) : this(null, year, month, 0) { }

        public GetWorkedHoursList(int year, int month, int day) : this(null, year, month, day) { }

        public GetWorkedHoursList(int year, int month, int day, List<Guid> projectsIds) : this(projectsIds, year, month, day) { }

        public GetWorkedHoursList(List<Guid> projectsIds, int year=0, int month = 0, int day=0)
        {
            Criteria = c => (null== projectsIds || projectsIds.Contains(c.ProjectId)) && (year == 0 || c.Date.Year == year) && (month == 0 || c.Date.Month == month) && (day == 0 || c.Date.Day == day);
            ApplyOrderBy(o => o.Date);
            IncludeStrings.Add($"{nameof(CrmApiLogic.Models.Projects.Project)}.{nameof(CrmApiLogic.Models.Customers.Customer)}");
        }


    }
}
