using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrder()
        {
            return _db.Orders;
        }

        [HttpGet("{orderId:int}")]
        public async Task<ActionResult<Order>> GetById(int orderId)
        {
            var order = await _db.Orders.FindAsync(orderId);
            return order;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Order order)
        {
            _db.Orders.Update(order);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{orderId:int}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            var order = await _db.Orders.FindAsync(id);
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
