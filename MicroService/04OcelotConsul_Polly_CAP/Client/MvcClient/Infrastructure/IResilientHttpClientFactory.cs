using Resilience.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClient.Infrastructure
{
    interface IResilientHttpClientFactory
    {
        ResilientHttpClient CreateResilientHttpClient();
    }
}
