using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmApiLogic;
using CrmApiLogic.Interfaces;
using CrmApiLogic.Models.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {

        public CustomersController(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper)
        {
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers(string q=null)
        {
            return await RepoWrapper.CustomerRepository.ListAsync(new CrmApiLogic.Specifications.Customer.FindCustomer(q));
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(Guid id)
        {
            var customer = await RepoWrapper.CustomerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await RepoWrapper.CustomerRepository.Edit(customer);

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await RepoWrapper.CustomerRepository.Add(customer);

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(Guid id)
        {
            if (RepoWrapper.CustomerRepository.Exists(id))
            {
                return NotFound();
            }

            await RepoWrapper.CustomerRepository.Delete(id);

            return Ok();
        }

        
    }
}
