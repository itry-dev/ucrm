using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CrmTests.WorkedHours.Api
{
    public class ApiTest : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture _fixture;

        public ApiTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task workedHoursOnProject_test()
        {
            //add a customer
            var companyId = Guid.NewGuid();
            var customer = new CrmApiLogic.Models.Customers.Customer
            {
                Id = companyId,
                CompanyName="test company"
            };
            await new CrmApiLogic.Repositories.CustomerRepository(_fixture.getDb()).Add(customer);

            //add a project
            var projectId = Guid.NewGuid();
            var project = new CrmApiLogic.Models.Projects.Project
            {
                Id = projectId,
                Name = "test project",
                CustomerId = companyId
            };
            await new CrmApiLogic.Repositories.ProjectsRepository(_fixture.getDb()).Add(project);

            //add worked hours
            var wh = new CrmApiLogic.Models.Projects.WorkedHour
            {
                Date = new DateTime(2020, 1, 1),
                Hours = 8
            };
            await new CrmApiLogic.Repositories.WorkedHoursRepository(_fixture.getDb()).Add(wh);

            //api test result
            var genericRepo = new CrmApiLogic.Repositories.RepositoryWrapper(_fixture.getDb());
            var controller = new CrmApi.Controllers.WorkedHoursController(genericRepo);        
            var result = await controller.GetProjectWorkedHours(new List<Guid> { projectId }, wh.Date.Year);

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<CrmApiLogic.Models.Projects.WorkedHour>>(viewResult.ViewData.Model);
            Assert.True(model.Count() == 1);


        }
    }
}
