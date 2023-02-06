using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomer()
        {
            return _db.Customers;
        }

        [HttpGet("{customerId:int}")]
        public async Task<ActionResult<Customer>> GetById(int customerId)
        {
            var customer = await _db.Customers.FindAsync(customerId);
            return customer;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            await _db.Customers.AddAsync(customer);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Customer customer)
        {
            _db.Customers.Update(customer);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{customerId:int}")]
        public async Task<ActionResult> DeleteById(int customerId)
        {
            var customer = await _db.Customers.FindAsync(customerId);
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}

