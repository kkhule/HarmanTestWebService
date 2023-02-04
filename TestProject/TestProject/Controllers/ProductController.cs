using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;



namespace TestProject.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _iProductService;

        public ProductController(IProductService iProductService)
        {
            _iProductService = iProductService;
        }


        
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_iProductService.GetAllProducts());
        }

        
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _iProductService.GetProduct(id);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        
        [HttpPost]
        public ActionResult Post(Product product)
        {
           var productAdded=  _iProductService.AddProduct(product);

            var actionName = nameof(Get);
            var routeValues = new { id = productAdded.Id };
            return CreatedAtAction(actionName, routeValues, productAdded);
        }


        [HttpPut]
        public ActionResult Put(Product product)
        {
            if (_iProductService.UpdateProduct(product))
                return NoContent();
            return NotFound();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_iProductService.DeleteProduct(id))
                return NoContent();

            return NotFound();
        }
    }
}
