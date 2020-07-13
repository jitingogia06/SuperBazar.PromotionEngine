using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBazar.PromotionEngine.Entities
{   
    /// <summary>
    /// Interface for writing promotion rules
    /// </summary>
    public interface IPromotionRule
    {
        void Apply(Cart cart);
    }
}
