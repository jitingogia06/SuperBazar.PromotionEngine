using SuperBazar.PromotionEngine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBazar.PromotionEngine.PromotionRules
{
    public class PromotionRuleForA : IPromotionRule
    {
        private readonly int discountQuantity = 3;
        private readonly decimal discountPrice = 130;

        public PromotionRuleForA()
        {
            discountQuantity = 3;
            discountPrice = 130;
        }

        public void Apply(Cart cart)
        {
            decimal unitPrice = 0;
            int quantity = 0;
            decimal discount = 0;

            CartItem cartItem = cart.Items.Find(i => i.SkuId == "A");            
            
            if (cartItem != null && cartItem.Quantity > 0)
            {
                quantity = cartItem.Quantity;
                unitPrice = cartItem.UnitPrice;
                
                // Calculate discount per multiple 
                discount = (unitPrice * discountQuantity) - discountPrice;

                // Calculate discount across multiple
                discount = discount * (quantity / discountQuantity);

                // Apply discount to total
                cart.Total = cart.Total - discount;
                
            }
        }
    }
}
