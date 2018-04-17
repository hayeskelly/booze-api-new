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
        public IActionResult Post([FromBody]Order order)
        {
            Console.WriteLine("Entered Post()");
            Console.WriteLine("Order for: "+order.fname);
            
            if(order == null)
            {
                Console.WriteLine("Order is null");                
                return BadRequest();
            }

            //calculate total for order
            Product product = db.Products.Find(order.productID);
            var price = product.price;
            var total = order.quantity * price;
            Console.WriteLine("Calculated total of: "+total);
            order.total = total;

            //generate a pickup number
            Random rnd = new Random();
            int pickupNumber = rnd.Next(100, 1000);
            Console.WriteLine("Generated pickup number: "+pickupNumber);
            order.pickupNum = pickupNumber;

            this.db.Orders.Add(order);
            this.db.SaveChanges();

            return CreatedAtRoute("GetOrder", new {id = order.id}, order);
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
