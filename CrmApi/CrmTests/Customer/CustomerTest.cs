using System;
using System.Linq;
using Xunit;

namespace CrmTests.Customer
{
    public class CustomerTest : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture _fixture;

        public CustomerTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void selectCustomerTest()
        {
            //add a new customer
            var customer = new CrmApiLogic.Models.Customers.Customer
            {
                CompanyName = "The Foo Company",
                Email = "info@thefoocompany.com",
                CEOName = "John Doe"
            };

            var repo = new CrmApiLogic.Repositories.CustomerRepository(_fixture.getDb());
            repo.Add(customer).GetAwaiter().GetResult();

            //select the customer by a part of his name
            var result = repo.ListAsync(new CrmApiLogic.Specifications.Customer.FindCustomer("Foo")).GetAwaiter().GetResult();

            //test the result
            Assert.NotNull(result);
            Assert.True(result.Count == 1);

        }
    }
}
