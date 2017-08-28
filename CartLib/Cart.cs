using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartLib
{
    public class Cart
    {
        private List<CartItem> carts;

        public Cart(List<CartItem> carts)
        {
            this.carts = carts;
        }

        public double Calculate()
        {
            return 0;
        }
    }


    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
