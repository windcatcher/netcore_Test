using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiOderService
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Oid { get; set; }
        public decimal DeliverFee { get; set; }
        public double PayableFee { get; set; }
        public double TotalPrice { get; set; }
        public sbyte PaymentWay { get; set; }
        public sbyte? PaymentCash { get; set; }
        public sbyte? Delivery { get; set; }
        public sbyte? IsConfirm { get; set; }
        public sbyte IsPaiy { get; set; }
        public sbyte State { get; set; }
        public DateTime CreateDate { get; set; }
        public string Note { get; set; }
        public int BuyerId { get; set; }

        //public Buyer Buyer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
