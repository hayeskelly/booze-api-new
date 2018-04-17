using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuckIBooze.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuckIBooze.API.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly LiquorStoreContext db;
        public OrdersController(LiquorStoreContext db)
        {
            this.db = db;

            if (this.db.Orders.Count() == 0)
            {
                //handle this
            }
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
           return Ok(db.Orders);
        }

        [HttpGet("{id}", Name="GetOrder")]
        public IActionResult GetById(int id)
        {
            var order = db.Orders.Find(id);

            if(order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
        
        [HttpPost]
        public String Post([FromBody]Order order)
        {
            //calculate total for order
            Product product = db.Products.Find(order.productID);
            var price = product.price;
            var total = order.quantity * price;
            order.total = total;

            //generate a pickup number
            Random rnd = new Random();
            int pickupNumber = rnd.Next(100, 1000);
            order.pickupNum = pickupNumber;

            this.db.Orders.Add(order);
            this.db.SaveChanges();

            String returnData = order.total.ToString() + ", " + order.pickupNum.ToString();

            return returnData;
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Order newOrder)
        {
            if (newOrder == null || newOrder.id != id)
            {
                return BadRequest();
            }

            this.db.Orders.Update(newOrder);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = this.db.Orders.FirstOrDefault(x => x.id == id);

            if (order == null)
            {
                return NotFound();
            }

            this.db.Orders.Remove(order);
            this.db.SaveChanges();

            return NoContent();
        }
    }
    
}
