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
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private OrderContext _orderContext;
        private readonly ICapPublisher _publisher;

        public OrdersController(OrderContext orderContext, ICapPublisher publisher)
        {
            _publisher = publisher;
            this._orderContext = orderContext;
        }
        #region Oders
        // GET api/Orders
        [HttpGet]
        public async Task<IActionResult> Get(string oid = null, int? buyerId = null)
        {
            IEnumerable<Order> orders = null;
            if (oid != null)
            {
                if (buyerId != null)
                    orders = await _orderContext.Order.Include(p => p.OrderItems).Where(p => p.Oid == oid && p.BuyerId == buyerId).ToListAsync();
                else
                    orders = await _orderContext.Order.Include(p => p.OrderItems).Where(p => p.Oid == oid).ToListAsync();
            }
            else
            {
                if (buyerId != null)
                    orders = await _orderContext.Order.Include(p => p.OrderItems).Where(p => p.BuyerId == buyerId).ToListAsync();
                else
                    orders = await _orderContext.Order.Include(p => p.OrderItems).ToListAsync();
            }

            return Ok(orders);
        }

        // GET api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            var order = await _orderContext.Order.Include(p => p.OrderItems).FirstOrDefaultAsync(p => p.Id == id);
            if (order == null)
                throw new OrderDomainException($"错误的订单id {id}");
            return Ok(order);
        }


        // POST api/Orders
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Order value)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            //默认购买数量1
            var orderCount = new { SkuId = 52, Amount = 1 };

            var order = _orderContext.Order.Add(value);

            using (var transaction = _orderContext.Database.BeginTransaction())
            {
                _orderContext.SaveChanges();
                await _publisher.PublishAsync("Orderservices.Order.Create", orderCount, "FailCallbackFoo");

                transaction.Commit();
            }
            return Json(order);
        }
        /// <summary>
        /// Order 部分更新
        /// Patch api/Orders/5
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task PatchAsync(int id, [FromBody]JsonPatchDocument<Order> patchData)
        {
            var oldOrder = GetOrderById(id);
            //更新
            patchData.ApplyTo(oldOrder);
            var orderProduct = new { SkuId = 52, Amount = 1 };
            using (var transaction = _orderContext.Database.BeginTransaction())
            {

                await _orderContext.SaveChangesAsync();

                await _publisher.PublishAsync("Orderservices.Order.Create", orderProduct
                   , "FailCallbackFoo");

                transaction.Commit();
            }
        }


        // PUT api/Orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Order value)
        {
            var oldOrder = GetOrderById(value.Id);
            // UpdateOrder(value, oldOrder);
            _orderContext.Order.Update(oldOrder);
            _orderContext.SaveChangesAsync();
        }

        // DELETE api/Orders/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var order = GetOrderById(id);
            var details = order.OrderItems;
            _orderContext.OrderItem.RemoveRange(details);
            _orderContext.Order.Remove(order);
            await _orderContext.SaveChangesAsync();
        }
        #endregion

        #region details

        /// <summary>
        /// get the order OrderItems
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/OrderItems")]
        public IEnumerable<OrderItem> OrderItems(int id)
        {
            var order = GetOrderById(id);
            var details = _orderContext.OrderItem.Where(p => p.OrderId == id);
            return details;
        }


        // DELETE api/Orders/5/OrderItems/5
        [HttpDelete("{orderId}/OrderItems/{detailId}")]
        public async Task DeleteOrderItems(int orderId, int detailId)
        {
            var order = GetOrderById(orderId);
            var detail = _orderContext.OrderItem.SingleOrDefault(p => p.Id == detailId);
            order.OrderItems.Remove(detail);
            _orderContext.OrderItem.Remove(detail);
            _orderContext.Order.Update(order);
            await _orderContext.SaveChangesAsync();
        }

        // Post api/Orders/5/OrderItems
        [HttpPost("{orderId}/OrderItems")]
        public async Task CreateOrderItems(int orderId, [FromBody]OrderItem value)
        {
            var order = GetOrderById(orderId);
            order.OrderItems.Add(value);
            await _orderContext.SaveChangesAsync();
        }
        #endregion



        private Order GetOrderById(int id)
        {
            return _orderContext.Order.FirstOrDefault(p => p.Id == id);
        }



        private void UpdateOrder(Order orderNew, Order orderOld)
        {
            orderOld.BuyerId = orderOld.BuyerId;
            orderOld.CreateDate = orderOld.CreateDate;
            orderOld.DeliverFee = orderOld.DeliverFee;
            orderOld.Delivery = orderOld.Delivery;
            orderOld.OrderItems = orderOld.OrderItems;
            orderOld.IsConfirm = orderOld.IsConfirm;
            orderOld.IsPaiy = orderOld.IsPaiy;
            orderOld.Note = orderOld.Note;
            orderOld.Oid = orderOld.Oid;
            orderOld.PayableFee = orderOld.PayableFee;
            orderOld.PaymentCash = orderOld.PaymentCash;
            orderOld.PaymentWay = orderOld.PaymentWay;
            orderOld.State = orderOld.State;
            orderOld.TotalPrice = orderOld.TotalPrice;
        }
    }
}
