using System.Collections.Generic;

namespace ACMBL
{
    public class OrderItem
    {       
        public OrderItem()
        {
        }
        public OrderItem(int orderItemId)
        {
            this.OrderItemId = orderItemId;
        }

        public int OrderItemId { get; private set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }

        public bool Validate()
        {
            var isValid = true;

            if (ProductId <= 0) isValid = false;
            if (Quantity <= 0) isValid = false;
            if (UnitPrice == null) isValid = false;

            return isValid;
        }
    }
}