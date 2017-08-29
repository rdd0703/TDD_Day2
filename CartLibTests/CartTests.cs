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

        [TestMethod()]
        public void CalculateTest_第一集買了一本_第二集也買了一本_價格應為_190()
        {
            var carts = new List<CartItem>() {
                new CartItem() { Id = 1 ,BookName = "哈利波特 第一集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 2 ,BookName = "哈利波特 第二集" ,Price = 100 ,Quantity = 1 }
            };

            var target = new Cart(carts);
            var actual = target.Calculate();

            var expected = 190;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateTest_一二三集各買了一本_價格應為_270()
        {
            var carts = new List<CartItem>() {
                new CartItem() { Id = 1 ,BookName = "哈利波特 第一集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 2 ,BookName = "哈利波特 第二集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 3 ,BookName = "哈利波特 第三集" ,Price = 100 ,Quantity = 1 }
            };

            var target = new Cart(carts);
            var actual = target.Calculate();

            var expected = 270;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateTest_一二三四集各買了一本_價格應為_320()
        {
            var carts = new List<CartItem>() {
                new CartItem() { Id = 1 ,BookName = "哈利波特 第一集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 2 ,BookName = "哈利波特 第二集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 3 ,BookName = "哈利波特 第三集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 4 ,BookName = "哈利波特 第四集" ,Price = 100 ,Quantity = 1 }
            };

            var target = new Cart(carts);
            var actual = target.Calculate();

            var expected = 320;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateTest_一次買了整套_一二三四五集各買了一本_價格應為_375()
        {
            var carts = new List<CartItem>() {
                new CartItem() { Id = 1 ,BookName = "哈利波特 第一集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 2 ,BookName = "哈利波特 第二集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 3 ,BookName = "哈利波特 第三集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 4 ,BookName = "哈利波特 第四集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 5 ,BookName = "哈利波特 第五集" ,Price = 100 ,Quantity = 1 }
            };

            var target = new Cart(carts);
            var actual = target.Calculate();

            var expected = 375;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateTest_一二集各買了一本_第三集買了兩本_價格應為_370()
        {
            var carts = new List<CartItem>() {
                new CartItem() { Id = 1 ,BookName = "哈利波特 第一集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 2 ,BookName = "哈利波特 第二集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 3 ,BookName = "哈利波特 第三集" ,Price = 100 ,Quantity = 2 }
            };

            var target = new Cart(carts);
            var actual = target.Calculate();

            var expected = 370;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateTest_第一集買了一本_第二三集各買了兩本_價格應為_460()
        {
            var carts = new List<CartItem>() {
                new CartItem() { Id = 1 ,BookName = "哈利波特 第一集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 2 ,BookName = "哈利波特 第二集" ,Price = 100 ,Quantity = 2 },
                new CartItem() { Id = 3 ,BookName = "哈利波特 第三集" ,Price = 100 ,Quantity = 2 }
            };

            var target = new Cart(carts);
            var actual = target.Calculate();

            var expected = 460;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateTest_選便宜的算法_第一二三集各買了兩本_第四五集各買了一本_價格應為640()
        {
            var carts = new List<CartItem>() {
                new CartItem() { Id = 1 ,BookName = "哈利波特 第一集" ,Price = 100 ,Quantity = 2 },
                new CartItem() { Id = 2 ,BookName = "哈利波特 第二集" ,Price = 100 ,Quantity = 2 },
                new CartItem() { Id = 3 ,BookName = "哈利波特 第三集" ,Price = 100 ,Quantity = 2 },
                new CartItem() { Id = 3 ,BookName = "哈利波特 第四集" ,Price = 100 ,Quantity = 1 },
                new CartItem() { Id = 3 ,BookName = "哈利波特 第五集" ,Price = 100 ,Quantity = 1 }
            };

            var target = new Cart(carts);
            var actual = target.Calculate();

            var expected = 640;

            Assert.AreEqual(expected, actual);
        }
    }

}