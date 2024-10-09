using Microsoft.AspNetCore.Mvc;
using Website.Models;
using Website.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {

        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeController(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }


        // GET: api/<ProductTypeController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productTypeRepository.GetAll());
        }

        // GET api/<TypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TypeController>
        [HttpPost]
        public IActionResult Post(ProductType productType)
        {
            _productTypeRepository.Add(productType);
            return CreatedAtAction("Get", new { id = productType.Id }, productType); 
        }

        // PUT api/<TypeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProductType productType)
        {
            if (id != productType.Id)
            {
                return BadRequest(); 
            }
            _productTypeRepository.Update(productType);
            return NoContent();
                
        }

        // DELETE api/<TypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productTypeRepository.Delete(id);
            return NoContent() ;
        }
    }
}
