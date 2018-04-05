using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseMidware
{
   
    public class MyRequestMiddleWare
    {
        private RequestDelegate _next;

        public MyRequestMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
             context.Response.WriteAsync("this is MyRequestMiddleWare...");
            return this._next(context);
        }
    }
}
