using ApiOderService;
using ApiOrderService.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DotNetCore.CAP;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace UnitTest
{
    public class OrderControllerTest
    {

        private OrderContext InitOrderContext()
        {
            var options = new DbContextOptionsBuilder<OrderContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var orderContext = new OrderContext(options);
            orderContext.Order.Add(new Order()
            {
                Oid = "oid1",
                IsConfirm = 1,
                OrderItems = new List<OrderItem>() {
                    new OrderItem(){
                        ProductNo="ProductNo1",
                        SkuPrice=10,
                        OrderId=0,
                    },
                      new OrderItem(){
                        ProductNo="ProductNo2",
                        SkuPrice=102,
                        OrderId=0,
                    },
                }

            });
            orderContext.SaveChanges();
            return orderContext;
        }

        [Fact]
        public async Task Get_ReturnOrders_success()
        {
            var capPublishMoq = new Mock<ICapPublisher>();
            var capPublish = capPublishMoq.Object;
            var ordercontxst = InitOrderContext();
            var control = new OrdersController(ordercontxst, capPublish);
            var response = await control.Get();
            var result = response.Should().BeAssignableTo<ObjectResult>().Subject;
            var orders = result.Value.Should().BeAssignableTo<IEnumerable<Order>>().Subject;
            orders.FirstOrDefault().Oid.Should().Be("oid1");
            orders.FirstOrDefault().OrderItems.Single(p => p.Id == 2).SkuPrice.Should().Be(102);
        }
    }
}
