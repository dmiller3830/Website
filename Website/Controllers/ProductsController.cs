using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Website.Models;
using Website.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductsRepository _productsRepository;
        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }


        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productsRepository.GetAll());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post(Products products)         
            { 

                _productsRepository.Add(products);
            return CreatedAtAction("Get", new {id = products.Id}, products);
             
            } 

        

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Products products)
        {
            if (id != products.Id)
            {
                return BadRequest();
            }
            _productsRepository.Update(products); 
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productsRepository.Delete(id);
            return NoContent();
        }
    }
}
