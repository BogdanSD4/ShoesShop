using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CategoryType CategoryType { get; set; } 
        public string? products { get; set; }
    }

    public enum CategoryType
    {
        Woman,
        Man,
        Child,
    }
}
