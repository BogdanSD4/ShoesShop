using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Cart
{
    public class ShopCart
    {
        public ShopCart()
        {
            items = new List<ShopCartItem>();
        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public float CartTotal { get; set; }
        public List<ShopCartItem> items { get; set; }

        public void Add(ShopCartItem cartItem)
        {
            foreach (var item in items)
            {
                if(item.Name == cartItem.Name)
                {
                    item.Quantity++;
					CartTotal += cartItem.Price;
					return;
                }
            }
			CartTotal += cartItem.Price;
			items.Add(cartItem);
			
		}

        public void Remove(ShopCartItem cartItem)
        {
            Action remove = () => { };
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == cartItem.Name)
                {
                    if (--items[i].Quantity <= 0)
                    {
                        remove = () => { items.RemoveAt(i); };
                    }
                    CartTotal -= items[i].Price;
                    break;
                }
            }
            remove();
        }
    }
}
