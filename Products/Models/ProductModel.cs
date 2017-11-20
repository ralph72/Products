using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public IList<Part> Parts { get; set; } = new List<Part>(); 

        public ProductModel()
        { }

        public ProductModel(string name)
        {
            this.Name = name;
        }
    }
}
