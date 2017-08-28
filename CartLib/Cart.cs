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

            var discount = (100 - GetDiscount(this._carts.Count)) / 100;

            var price = 0;

            foreach (var item in this._carts)
            {
                price += (int)(item.Price * item.Quantity * discount);
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
