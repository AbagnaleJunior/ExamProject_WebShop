using Microsoft.AspNetCore.Mvc;
using RedPillCorp.WebShop.Application.IServices;
using RedPillCorp.WebShop.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedPillCorp.WebShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductCategoryController(IProductService service)
        {
            _service = service;
        }

        // GET: api/<ProductCategoryController>
        [HttpGet]
        public List<ProductCategory> Get()
        {
            // Value Tuple kan ikke automatisk serialseres via dot.net 5.0 standard json serializer
            return _service.GetAllCategories();
        }

        // GET api/<ProductCategoryController>/5
        [HttpGet("{id}")]
        public ProductCategory Get(Guid id)
        {
            return _service.ProductCategory_GetById(id);
        }

        // POST api/<ProductCategoryController>
        [HttpPost]
        public ProductCategory Post([FromBody] ProductCategory productCategory)
        {
            return _service.ProductCategory_Create(productCategory);
        }

        /*// PUT api/<ProductCategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<ProductCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _service.ProductCategory_Delete(id);
        }
    }
}
