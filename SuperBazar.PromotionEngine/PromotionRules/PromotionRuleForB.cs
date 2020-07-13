using SuperBazar.PromotionEngine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBazar.PromotionEngine.PromotionRules
{
    public class PromotionRuleForB : IPromotionRule
    {
        private readonly int discountQuantity;
        private readonly decimal discountPrice;

        public PromotionRuleForB()
        {
            discountQuantity = 2;
            discountPrice = 45;
        }

        public void Apply(Cart cart)
        {
            decimal unitPrice = 0;
            int quantity = 0;
            decimal discount = 0;

            CartItem cartItem = cart.Items.Find(i => i.SkuId == "B");

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
