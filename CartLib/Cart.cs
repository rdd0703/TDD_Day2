using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartLib
{
    public class Cart
    {
        private List<CartItem> _carts;

        public Cart(List<CartItem> carts)
        {
            this._carts = carts;
        }

        public double Calculate()
        {
            if (this._carts == null) return 0;

            //平均組合計算法
            int price1 = GetAvgPrice(this._carts);
            //一般依序計算法
            int price2 = GetNormalPrice(this._carts);


            return price1 < price2 ? price1 : price2;
        }

        /// <summary>一般依序計算法</summary>
        private int GetNormalPrice(List<CartItem> carts)
        {
            var price = 0;
            var maxCombineCount = carts.Max(d => d.Quantity);

            for (int i = 1; i <= maxCombineCount; i++)
            {
                var combineCarts = carts.Where(d => d.Quantity > 0).ToList();
                var discount = (100 - GetDiscount(combineCarts.Count)) / 100;

                foreach (var item in combineCarts)
                {
                    price += (int)(item.Price * 1 * discount);
                    item.Quantity--;
                }
            }
            return price;
        }

        /// <summary>平均組合計算法</summary>
        private int GetAvgPrice(List<CartItem> carts)
        {
            var price = 0;
            var maxCombineCount = carts.Max(d => d.Quantity);

            var lstPrice = new List<double>();
            foreach (var item in carts)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    lstPrice.Add(item.Price);
                }
            }

            var oneCombineCount = lstPrice.Count / maxCombineCount;
            for (int i = 0; i < maxCombineCount; i++)
            {
                var discount = (100 - GetDiscount(oneCombineCount)) / 100;
                price += (int)lstPrice.Skip(i).Take(oneCombineCount).Sum(d => d * discount);

                oneCombineCount = lstPrice.Count - oneCombineCount;
            }

            return price;
        }

        /// <summary>依傳入的數量傳回折扣數(%)</summary>
        private double GetDiscount(int count)
        {
            switch (count)
            {
                case 1:
                    return 0;
                case 2:
                    return 5;
                case 3:
                    return 10;
                case 4:
                    return 20;
                case 5:
                    return 25;
                default:
                    return 0;
            }
        }
    }


    public class CartItem
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
