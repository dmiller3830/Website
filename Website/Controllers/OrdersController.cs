using Microsoft.AspNetCore.Mvc;
using Website.Models;
using Website.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrdersRepository _ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }


        // GET: api/<OrdersController>
        [HttpGet]
        public IActionResult Get()
        {
           return Ok(_ordersRepository.GetAll());
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post(Orders orders)
        {
            _ordersRepository.Add(orders);
            return CreatedAtAction("Get", new {id = orders.Id}, orders);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Orders orders)
        {
            if (id != orders.Id)
            {
                return BadRequest(); 
            }
            _ordersRepository.Update(orders);
            return NoContent();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ordersRepository.Delete(id);
            return NoContent();
        }
    }
}
