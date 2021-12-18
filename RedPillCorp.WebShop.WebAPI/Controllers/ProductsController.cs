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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET: api/<ProductController>
        [HttpGet("GetAllIdsAndNames")]
        public List<DTO.ProductIdAndNamesDTO> GetAllIdsAndNames()
        {
            // Value Tuple kan ikke automatisk serialseres via dot.net 5.0 standard json serializer
            List<(Guid, string)> list = _service.Product_GetAllIdsAndNames();

            return list.Select(x => new DTO.ProductIdAndNamesDTO
            {
                Id = x.Item1,
                Name = x.Item2

            }).ToList();
        }

        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> Get()
        {
            return _service.Product_GetAll();
        }


        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(Guid id)
        {
            return _service.Product_GetById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public Product Post(Product product)
        {
            return _service.Product_Create(product);
        }

        /*// PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _service.Product_Delete(id);
        }
    }
}
