using NUnit.Framework;
using SuperBazar.PromotionEngine.Entities;
using SuperBazar.PromotionEngine.PromotionRules;
using System;
using System.Collections.Generic;

namespace SuperBazar.PromotionEngine.Test
{
    public class PromitionEngineTest
    {
        private List<IPromotionRule> rules; 
        private PromotionEngine engine;
        private Cart cart;
        private Dictionary<string, decimal> priceList;

        [SetUp]
        public void Setup()
        {
            // Prepare price list
            priceList = new Dictionary<string, decimal>() {
                { "A", 50 },
                { "B", 30 },
                { "C", 20 },
                { "D", 15 }
            };

            //Prepare rules list  
            rules = new List<IPromotionRule>() {
                new PromotionRuleForA(),
                new PromotionRuleForB(),
                new PromotionRuleForCD() 
            };

            // Create engine
            engine = new PromotionEngine(rules);
        }

        [Test]
        public void TestScenarioA()
        {
            cart = new Cart("ABC", DateTime.Now, new List<CartItem>(){
                new CartItem("A", 1, priceList["A"]),
                new CartItem("B", 1, priceList["B"]),
                new CartItem("C", 1, priceList["C"])
                }); 
            
            engine.Promote(cart);
            
            Assert.AreEqual(cart.Total, 100);
        }

        [Test]
        public void TestScenarioB()
        {
            cart = new Cart("ABC", DateTime.Now, new List<CartItem>(){
                new CartItem("A", 5, priceList["A"]),
                new CartItem("B", 5, priceList["B"]),
                new CartItem("C", 1, priceList["C"])
                });

            engine.Promote(cart);

            Assert.AreEqual(370, cart.Total);
        }

        [Test]
        public void TestScenarioC()
        {
            cart = new Cart("ABC", DateTime.Now, new List<CartItem>(){
                new CartItem("A", 3, priceList["A"]),
                new CartItem("B", 5, priceList["B"]),
                new CartItem("C", 1, priceList["C"]),
                new CartItem("D", 1, priceList["D"])
                });

            engine.Promote(cart);

            Assert.AreEqual(280, cart.Total);
        }
    }
}