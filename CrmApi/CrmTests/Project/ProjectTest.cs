using System;
using System.Linq;
using Xunit;

namespace CrmTests.Project
{
    public class ProjectTest : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture _fixture;

        public ProjectTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void searchProjectTest()
        {
            //add a new customer
            var project = new CrmApiLogic.Models.Projects.Project
            {
                Name = "The Foo Project"                
            };

            var repo = new CrmApiLogic.Repositories.ProjectsRepository(_fixture.getDb());
            repo.Add(project).GetAwaiter().GetResult();

            //select the customer by a part of his name
            var result = repo.ListAsync(new CrmApiLogic.Specifications.Project.FindProject("Foo")).GetAwaiter().GetResult();

            //test the result
            Assert.NotNull(result);
            Assert.True(result.Count == 1);

        }

        [Fact]
        public void getProjectsTest()
        {
            var repo = new CrmApiLogic.Repositories.ProjectsRepository(_fixture.getDb());

            //add a new customer
            var project = new CrmApiLogic.Models.Projects.Project
            {
                Name = "The Foo Project"
            };
            repo.Add(project).GetAwaiter().GetResult();

            project = new CrmApiLogic.Models.Projects.Project
            {
                Name = "The Foo Project 2"
            };
            repo.Add(project).GetAwaiter().GetResult();
            

            //select the customer by a part of his name
            var result = repo.ListAsync(new CrmApiLogic.Specifications.Project.FindProject("Foo")).GetAwaiter().GetResult();

            //test the result
            Assert.NotNull(result);
            Assert.True(result.Count == 2);

        }
    }
}
