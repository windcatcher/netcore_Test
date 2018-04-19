using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiProductService.config
{
    public class ServiceDisvoveryOptions
    {
        public string RegisterServiceName { get; set; }
        public string DiscoveryServiceName { get; set; }
        public string ConsulUrl { get; set; }
        public string RegisterServerUrl { get; set; }
        public string DiscoverDnsUrl { get; set; }
    }
}
