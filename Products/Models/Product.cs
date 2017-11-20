using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Models
{
    //Represents a product, which can have several product models under it.
    public class Product
    {
        public Product()
        { }

        public Product(string name)
        {
            this.Name = name;
        }

        public IDictionary<string, ProductModel> ProductModels { get; } = new Dictionary<string, ProductModel>(StringComparer.CurrentCultureIgnoreCase);
        public string Name { get; set; } = "";
    }
}
