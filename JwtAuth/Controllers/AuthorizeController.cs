using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuth.Controllers {
   // [Route ("api/[controller]")]
    public class AuthorizeController : Controller {

        private JwtSetting _jwtSetting;
        public AuthorizeController (IOptions<JwtSetting> jwtSettins) {
            _jwtSetting = jwtSettins.Value;
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <remarks>
        /// Sample Request
        /// 
        ///     POST /api/authorize/token
        ///     {
        ///         "user":"jesse",
        ///         "password":"123456"        
        ///     }
        /// </remarks>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Token ([FromBody] LoginViewModel viewModel) {
            if (!ModelState.IsValid)
                return BadRequest ();
            if (!(viewModel.User == "lms" && viewModel.Pwd == "123456"))
                return BadRequest ();
            var claims = new Claim[] {
                new Claim (ClaimTypes.Name, "lms"),
                new Claim (ClaimTypes.Role, "admin")
            };
            var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (_jwtSetting.ScrectKey));
            var credit = new SigningCredentials (key, SecurityAlgorithms.Aes128CbcHmacSha256);

            var token = new JwtSecurityToken (
                _jwtSetting.Issuser,
                _jwtSetting.Audience,
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes (30),
                credit
            );

            return Ok (new { token = new JwtSecurityTokenHandler ().WriteToken (token) });
        }

      
       [HttpGet]
        public IActionResult Token1 ([FromBody] LoginViewModel viewModel) {
            if (!ModelState.IsValid)
                return BadRequest ();
            if (!(viewModel.User == "lms" && viewModel.Pwd == "123456"))
                return BadRequest ();
            var claims = new Claim[] {
                new Claim (ClaimTypes.Name, "lms"),
                new Claim (ClaimTypes.Role, "admin")
            };
            var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (_jwtSetting.ScrectKey));
            var credit = new SigningCredentials (key, SecurityAlgorithms.Aes128CbcHmacSha256);

            var token = new JwtSecurityToken (
                _jwtSetting.Issuser,
                _jwtSetting.Audience,
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes (30),
                credit
            );

            return Ok (new { token = new JwtSecurityTokenHandler ().WriteToken (token) });
        }
    }
}