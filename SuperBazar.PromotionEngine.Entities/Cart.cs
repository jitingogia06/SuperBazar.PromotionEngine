using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperBazar.PromotionEngine.Entities
{
    public class Cart
    {
        public string CustomerId { get; private set; }
        public DateTime PurchaseTimeStamp { get; private set; }
        public List<CartItem> Items { get; private set; }
        public decimal GrossTotal 
        {
            get
            {
                return Items.Sum(i => i.Total);
            }
        }

        public decimal Total { get; set; }
        
        // Constructor
        public Cart(string customerId, DateTime purchaseTimeStamp, List<CartItem> items)
        {
            CustomerId = customerId;
            PurchaseTimeStamp = purchaseTimeStamp;
            Items = items;
        }
    }
}
