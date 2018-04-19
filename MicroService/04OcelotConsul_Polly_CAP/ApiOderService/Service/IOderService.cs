using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOderService.Service
{
    public interface IOderService
    {
        Order CreateOder();
        IEnumerable<Order> GetOrders();

       
    }
}
