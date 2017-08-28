using Microsoft.VisualStudio.TestTools.UnitTesting;
using CartLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartLib.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void CalculateTest_第一集買了一本_其他都沒買_價格應為_100元()
        {
            var carts = new List<CartItem>() {
                new CartItem() { Id = 1 ,BookName = "哈利波特 第一集" ,Price = 100 ,Quantity = 1 }
            };

            var target = new Cart(carts);
            var actual = target.Calculate();

            var expected = 100;

            Assert.AreEqual(expected, actual);
        }
    }
    
}