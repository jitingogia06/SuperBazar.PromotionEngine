using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBazar.PromotionEngine.Entities
{
    public class CartItem
    {
        public string SkuId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Total 
        {            
            get 
            {
                return Quantity * UnitPrice;
            }
        }

        public CartItem(string skuId, int quantity, decimal unitPrice)
        {
            SkuId = skuId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
