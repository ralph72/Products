using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Models
{
    public class OrderedProducts
    {
        public IList<OrderedProductUI> Products { get; } = new ObservableCollection<OrderedProductUI>();


    }
}
