using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiUserService
{
    public class ServiceDisvoveryOptions
    {
        public string RegisterServiceName { get; set; }
        public string ConsulUrl { get; set; }
        public string RegisterServerUrl { get; set; }
    }

   
}
