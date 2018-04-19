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
    public class ColorsController : Controller
    {
        private IColorRepository ColorRep;

        public ColorsController(IColorRepository ColorRep)
        {
            this.ColorRep = ColorRep;
        }

        // GET api/Colors
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Colors = ColorRep.getColorList(null);
            return Ok(Colors);
        }

        // GET api/Colors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            var Color = ColorRep.getColorByKey(id);
            if (Color == null)
                throw new ProductDomainException($"错误的Colorid {id}");
            return Ok(Color);
        }


        // POST api/Colors
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Color value)
        {
            var id =  ColorRep.addColor(value);

            return CreatedAtAction(nameof(Get), new { id = id }, null);
        }
        /// <summary>
        /// Color 部分更新
        /// Patch api/Colors/5
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task PatchAsync(int id, [FromBody]JsonPatchDocument<Color> patchData)
        {
            var oldColor = ColorRep.getColorByKey(id);
            //更新
            patchData.ApplyTo(oldColor);
            ColorRep.updateColorByKey(oldColor);
        }

        // PUT api/Colors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Color value)
        {
            var oldColor = ColorRep.getColorByKey(id);
            if (oldColor == null)
                throw new ProductDomainException($"错误的Colorid {id}");
            value.Id = id;
            var newid = ColorRep.updateColorByKey(value);

            return CreatedAtAction(nameof(Get), new { id = newid }, null);
        }

        // DELETE api/Colors/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            ColorRep.deleteByKey(id);
        }

    }
}
