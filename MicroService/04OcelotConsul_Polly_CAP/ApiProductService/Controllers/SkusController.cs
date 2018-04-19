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
    public class SkusController : Controller
    {
        private ISkuRepository SkuRep;

        public SkusController(ISkuRepository SkuRep)
        {
            this.SkuRep = SkuRep;
        }

        // GET api/Skus
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Skus = SkuRep.getSkuList(null);
            return Ok(Skus);
        }

        // GET api/Skus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            var Sku = SkuRep.getSkuByKey(id);
            if (Sku == null)
                throw new ProductDomainException($"错误的Skuid {id}");
            return Ok(Sku);
        }


        // POST api/Skus
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Sku value)
        {
            var id =  SkuRep.addSku(value);

            return CreatedAtAction(nameof(Get), new { id = id }, null);
        }
        /// <summary>
        /// Sku 部分更新
        /// Patch api/Skus/5
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task PatchAsync(int id, [FromBody]JsonPatchDocument<Sku> patchData)
        {
            var oldSku = SkuRep.getSkuByKey(id);
            //更新
            patchData.ApplyTo(oldSku);
            SkuRep.updateSkuByKey(oldSku);
        }

        // PUT api/Skus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Sku value)
        {
            var oldSku = SkuRep.getSkuByKey(id);
            if (oldSku == null)
                throw new ProductDomainException($"错误的Skuid {id}");
            value.Id = id;
            var newid = SkuRep.updateSkuByKey(value);

            return CreatedAtAction(nameof(Get), new { id = newid }, null);
        }

        // DELETE api/Skus/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            SkuRep.deleteByKey(id);
        }

    }
}
