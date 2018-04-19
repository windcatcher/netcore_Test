using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProductService;
using ApiProductService.Infrastructure.Exceptions;
using ApiProductService.Infrastructure.Repositories;
using DotNetCore.CAP;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApiProductService.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductRepository productRep;
        private readonly ICapPublisher _publisher;

        public ProductsController(IProductRepository productRep, ICapPublisher publisher)
        {
            _publisher = publisher;
            this.productRep = productRep;
        }

        // GET api/Products
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Products = await productRep.getProductList(null);
            return Ok(Products);
        }

        // GET api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            var Product = await productRep.getProductByKey(id);
            if (Product == null)
                throw new ProductDomainException($"错误的产品id {id}");
            return Ok(Product);
        }


        // POST api/Products
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Product value)
        {
            var id = await productRep.addProduct(value);

            return CreatedAtAction(nameof(Get), new { id = id }, null);
        }
        /// <summary>
        /// Product 部分更新
        /// Patch api/Products/5
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task PatchAsync(int id, [FromBody]JsonPatchDocument<Product> patchData)
        {
            var oldProduct = await productRep.getProductByKey(id);
            //更新
            patchData.ApplyTo(oldProduct);
            await productRep.updateProductByKey(oldProduct);
        }

        // PUT api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Product value)
        {
            var oldProduct = await productRep.getProductByKey(id);
            if (oldProduct == null)
                throw new ProductDomainException($"错误的产品id {id}");
            value.Id = id;
            var newid = await productRep.updateProductByKey(value);

            return CreatedAtAction(nameof(Get), new { id = newid }, null);
        }

        // DELETE api/Products/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await productRep.deleteByKey(id);
        }

    }
}
