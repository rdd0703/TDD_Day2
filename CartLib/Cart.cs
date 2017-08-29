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


            var maxQuantity = this._carts.Max(d => d.Quantity);
            var price = 0;

            for (int i = 1; i <= maxQuantity; i++)
            {
                //組合項目
                var combineCarts = this._carts.Where(d => d.Quantity > 0).ToList();
                //取得該組合的折扣
                var discount = (100 - GetDiscount(combineCarts.Count)) / 100;

                //計算該組合的價格
                foreach (var item in combineCarts)
                {
                    price += (int)(item.Price * 1 * discount);
                    item.Quantity--;
                }
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
