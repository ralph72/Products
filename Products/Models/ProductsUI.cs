using Products.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class ProductsUI
    {
        public const string ADD_TAG_TEXT = "  +  ";
        public const string NEW_TAG_TEXT = "<New Model>";

        private IList<ProductUI> models = new ObservableCollection<ProductUI>();

        public ProductsUI()
        {
            foreach(Product p in Repositories.Products.Products.Values)
            {
                ProductUI ui = new ProductUI();
                ui.Name = p.Name;
                this.models.Add(ui);
            }

            if(this.models.Count == 0)
            {
                ProductUI ui2 = new ProductUI(NEW_TAG_TEXT, "");
                this.models.Add(ui2);
            }

            ProductUI ui3 = new ProductUI(ADD_TAG_TEXT, "");
            this.models.Add(ui3);
        }

        public IList<ProductUI> Models
        {
            get
            {
                return this.models;
            }
        }
    }
}
