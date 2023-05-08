using Shop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shop.Models.Mocks
{
    public class MockProducts : IProducts
    {
        private readonly ICategory _categories = new MockCatagory();

        public IEnumerable<Product> products { get 
            {
                return new List<Product>
                {
                    new Product()
                    {
                        name = "New Balance Fresh Foam 1080v11",
                        description = "Men's Running Shoes",
                        price = 149.99f,
                        img = string.Join(",", new [] {
                            "/img/New Balance Fresh Foam 1080v11.jpg",
                            "/img/Skechers Summits Light Dreaming.jpg",
                            "/img/Nike Air Max 270 React.jpg"
                        }),
                        quantity = 100,
                        categories = JsonSerializer.Serialize(new int[]{ 1, 2 }),
                    },
                    new Product()
                    {
                        name = "Skechers Summits Light Dreaming",
                        description = "Women's Walking Shoes",
                        price = 59.99f,
                        img = string.Join(",", new[] {"/img/Skechers Summits Light Dreaming.jpg"}),
                        quantity = 130,
                        categories = JsonSerializer.Serialize(new int[]{ 0 }),
                    },
                    new Product()
                    {
                        name = "Nike Air Max 270 React",
                        description = "Men's Running Shoes",
                        price = 129.99f,
                        img = string.Join(",", new[] { "/img/Nike Air Max 270 React.jpg" }),
                        quantity = 150,
                        categories = JsonSerializer.Serialize(new int[]{ 1 }),
                    },
                    new Product()
                    {
                        name = "Adidas Ultraboost 21",
                        description = "Women's Running Shoes",
                        price = 149.99f,
                        img = string.Join(",", new[] { "/img/AdidasUltraboost21.jpg" }),
                        quantity = 120,
                        categories = JsonSerializer.Serialize(new int[]{ 0, 2 }),
                    },
                    new Product()
                    {
                        name = "Puma RS-Fast Tech Sneakers",
                        description = "Men's Casual Shoes",
                        price = 119.99f,
                        img = string.Join(",", new[] { "/img/Puma RS-Fast Tech Sneakers.jpg" }),
                        quantity = 200,
                        categories = JsonSerializer.Serialize(new int[]{ 1 }),
                    },
                    new Product()
                    {
                        name = "Converse Chuck Taylor All Star",
                        description = "Women's Casual Shoes",
                        price = 49.99f,
                        img = string.Join(",", new [] {"/img/Converse Chuck Taylor All Star.jpg"}),
                        quantity = 80,
                        categories = JsonSerializer.Serialize(new int[]{ 0 }),
                    },
                };
            }
        }

        public Product GetProduct(int id)
        {
            return products.ToArray()[id];
        }
    }
}
