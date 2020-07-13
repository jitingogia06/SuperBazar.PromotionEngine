using SuperBazar.PromotionEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperBazar.PromotionEngine
{
    /// <summary>
    /// Applies promotion rules
    /// </summary>
    public class PromotionEngine
    {
        List<IPromotionRule> _promotionRules;        

        public PromotionEngine(List<IPromotionRule> promotionRules)
        {
            _promotionRules = promotionRules;            
        }

        public void Promote(Cart cart)
        {
            cart.Total = cart.GrossTotal;
            
            // Apply promotion rules
            foreach (IPromotionRule rule in _promotionRules)
            {
                rule.Apply(cart); 
            }
        }
    }
}
