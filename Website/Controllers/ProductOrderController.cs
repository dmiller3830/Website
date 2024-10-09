using Microsoft.AspNetCore.Mvc;
using Website.Models;
using Website.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrderController : ControllerBase
    {

        private readonly IProductOrderRepository _productOrderRepository; 

        public ProductOrderController(IProductOrderRepository productOrderRepository)
        {
            _productOrderRepository = productOrderRepository;
        }


        // GET: api/<ProductOrderController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productOrderRepository.GetAll());
        }

        // GET api/<ProductOrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductOrderController>
        [HttpPost]
        public IActionResult Post(ProductOrder productOrder)
        {
            _productOrderRepository.Add(productOrder);
            return CreatedAtAction("Get", new { id = productOrder.Id }, productOrder);

        }

        // PUT api/<ProductOrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProductOrder productOrder)
        {
            if (id != productOrder.Id)
            {
                return BadRequest();
            }
            _productOrderRepository.Update(productOrder);
            return NoContent();

        }

        // DELETE api/<ProductOrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        { _productOrderRepository.Delete(id);
            return NoContent();
        }
    }
}
