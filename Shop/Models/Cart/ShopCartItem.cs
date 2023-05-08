using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Cart
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        [AllowNull] public string Name { get; set; }
        [AllowNull] public string Img { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int ShopCartId { get; set; }
    }
}
