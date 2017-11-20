using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Models
{
    public class Repositories
    {
        public static ProductList Products { get; set; }

        public static ProductsUI ProductsUI { get; set; }

        public static OrderedProducts OrderedProducts { get; set; } = new OrderedProducts();
    }
}
