using System;

namespace SuperBazar.PromotionEngine.Entities
{
    public class SKU
    {
        public string Id { get; private set; }
        public decimal UnitPrice { get; private set;}

        public SKU(string id, decimal unitPrice)
        {
            Id = id;
            UnitPrice = unitPrice; 
        }
    }
}
