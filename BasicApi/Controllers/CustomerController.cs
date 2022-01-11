using BasicApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BasicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public ApplicationContext Context { get; set; }

        public CustomerController(ApplicationContext context)
        {
            Context = context;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            var result = Context.Customers.ToList();
            return result;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var result = Context.Customers.Where(a => a.CustomerId == id).FirstOrDefault();

            if(result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            Context.Customers.Add(customer);
            Context.SaveChanges();
            return Ok(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer value)
        {
            var customer = Context.Customers.Where(a => a.CustomerId == id).FirstOrDefault();

            if(customer is null)
            {
                return NotFound();
            }

            customer.FirstName = value.FirstName;
            customer.LastName = value.FirstName;
            customer.Email = value.Email;
            customer.Gender = value.FirstName;
            customer.Address = value.FirstName;
            customer.City = value.FirstName;
            customer.Country = value.FirstName;

            Context.Update(customer);
            Context.SaveChanges();

            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = Context.Customers.Where(a => a.CustomerId == id).FirstOrDefault();

            if(customer is null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
