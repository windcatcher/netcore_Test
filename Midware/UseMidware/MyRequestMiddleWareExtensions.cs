using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseMidware
{
    public static class MyRequestMiddleWareExtensions
    {
        public static IApplicationBuilder UseMyRequestMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyRequestMiddleWare>();
        }
    }
}
