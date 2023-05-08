using Newtonsoft.Json;
using Shop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Product
    {
        public int id {  get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? img { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public string? categories { get; set; }
    }
}
