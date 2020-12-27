using System;
using System.Collections.Generic;
using Commmon;

namespace ACMBL
{
    public class Order : EntityBase, ILoggable
    {
        public Order():this(0)
        {
        }
        public Order(int orderId)
        {
            this.OrderId = orderId;
            OrderItems = new List<OrderItem>();
        }

        public int OrderId { get; private set; }
        public DateTimeOffset? OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int ShippingAddressId { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public string Log() =>
            $"{OrderId}: Date:{OrderDate}, Status:{EntityState.ToString()}";

        public override string ToString() => $"{OrderDate} Id:{OrderId}";
    
        public override bool Validate()
        {
            var isValid = true;
            if (OrderDate == null) isValid = false;

            return isValid;
        }
    }
}