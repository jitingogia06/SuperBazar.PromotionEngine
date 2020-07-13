using SuperBazar.PromotionEngine.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBazar.PromotionEngine.PromotionRules
{
    public class PromotionRuleForCD : IPromotionRule
    {
        private readonly decimal discountPrice;

        public PromotionRuleForCD()
        {
            discountPrice = 30;
        }

        public void Apply(Cart cart)
        {
            int quantity = 0;
            decimal total = cart.Total;

            CartItem cartItemC = cart.Items.Find(i => i.SkuId == "C");
            CartItem cartItemD = cart.Items.Find(i => i.SkuId == "D");

            if (cartItemC != null && cartItemC.Quantity > 0 && cartItemD != null && cartItemD.Quantity > 0)
            {
                if (cartItemC.Quantity < cartItemD.Quantity)
                {
                    quantity = cartItemC.Quantity;
                }
                else
                {
                    quantity = cartItemD.Quantity;
                }
                
                // Remove totals of cartItem C & D
                total -= (quantity * cartItemC.UnitPrice);
                total -= (quantity * cartItemD.UnitPrice);

                // Add the new total for discounted price
                total += quantity * discountPrice;

                // Update total
                cart.Total = total;
            }
        }
    }
}
