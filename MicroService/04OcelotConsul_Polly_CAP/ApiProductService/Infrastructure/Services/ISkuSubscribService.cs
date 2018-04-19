using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Services
{
    public interface ISkuSubscribService
    {
        void ReceiveCreateOrderMessage(dynamic orderInfo);
    }
}
