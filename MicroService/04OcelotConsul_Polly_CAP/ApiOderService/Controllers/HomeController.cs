using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiOderService;
using ApiOderService.Dtos;
using ApiOderService.Infrastructure.Exceptions;
using DotNetCore.CAP;
using DotNetCore.CAP.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApiOrderService.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
