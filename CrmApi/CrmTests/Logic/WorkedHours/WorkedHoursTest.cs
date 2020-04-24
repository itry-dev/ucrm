using System;
using System.Linq;
using Xunit;

namespace CrmTests.WorkedHours
{
    public class WorkedHoursTest : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture _fixture;

        public WorkedHoursTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void workedHoursTest()
        {
            //add few worked hours
            var wh = new CrmApiLogic.Models.Projects.WorkedHour
            {
                Date = new DateTime(2020,1,1),
                Hours = 8
            };

            var wh1 = new CrmApiLogic.Models.Projects.WorkedHour
            {
                Date = new DateTime(2020, 1, 2),
                Hours = 8
            };

            var repo = new CrmApiLogic.Repositories.WorkedHoursRepository(_fixture.getDb());
            repo.Add(wh).GetAwaiter().GetResult();
            repo.Add(wh1).GetAwaiter().GetResult();

            //select January workedhours 
            var result = repo.ListAsync(new CrmApiLogic.Specifications.Project.GetWorkedHoursList(2020,1,0)).GetAwaiter().GetResult();

            //test the result
            Assert.NotNull(result);
            Assert.True(result.Count == 2);

        }

        [Fact]
        public void totalAmountOnProject_test()
        {
            var customer = new CrmApiLogic.Models.Customers.Customer
            {
                Id=Guid.NewGuid(),
                CompanyName="Test Company"
            };
            _fixture.getDb().Customers.Add(customer);

            var pr = new CrmApiLogic.Models.Projects.Project
            {
                CustomerId = customer.Id,
                Name = "Test Project",
                HourlyRate = 250
            };
            _fixture.getDb().Projects.Add(pr);

            var wh = new CrmApiLogic.Models.Projects.WorkedHour
            {
                Date = new DateTime(2020, 1, 1),
                Hours = 8
            };
            _fixture.getDb().WorkedHours.Add(wh);

            var summary = new CrmApiLogic.Repositories.WorkedHoursRepository(_fixture.getDb()).GetReport(wh.Date.Year, wh.Date.Month, pr.Id).GetAwaiter().GetResult();

            Assert.NotNull(summary);
            Assert.True(summary.Count > 0);
        }

        

    }
}
