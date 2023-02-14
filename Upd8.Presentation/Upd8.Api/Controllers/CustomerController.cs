using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Upd8.Domain.Entities;
using Upd8.Domain.Interfaces.Services;

namespace Upd8.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: /Customer
        [HttpGet]
        public IActionResult Get()
        {
            var customers = customerService.GetAllCustomers();
            return Ok(customers);
        }

        // GET: /Customer/{id}
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var customer = customerService.GetCustomerById(id);
            return Ok(customer);
        }

        // POST: /Customer
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            var createdCustomer = customerService.AddCustomer(customer);

            return Created("", createdCustomer);
        }

        // PUT /Customer
        [HttpPut]
        public IActionResult Put([FromBody] Customer customer)
        {
            customerService.UpdateCustomer(customer);
            return Ok();
        }

        // DELETE /Customer/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            customerService.RemoveCustomer(id);
            return Ok();
        }
    }
}
