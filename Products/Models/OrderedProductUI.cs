using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Models
{
    public class OrderedProductUI : INotifyPropertyChanged
    {
        private Product selectedProduct = null;

        private ProductModel selectedModel = null;

        public Product SelectedProduct
        {
            get
            {
                return this.selectedProduct;
            }
            set
            {
                this.selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public ProductModel SelectedModel
        {
            get
            {
                return this.selectedModel;
            }
            set
            {
                this.selectedModel = value;
                OnPropertyChanged("SelectedModel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public OrderedProductUI()
        {
            this.Update();
        }

        public void Update()
        {
            this.Products.Clear();
            
            foreach(Product p in Repositories.Products.Products.Values)
            {
                this.Products.Add(p);
            }
            if (this.Products.Count > 0)
            {
                this.SelectedProduct = this.Products[0];
                this.UpdateModels();

            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateModels()
        {
            this.Quantity = 1;
            if (this.SelectedProduct != null)
            {
                this.Models.Clear();
                foreach (ProductModel m in this.SelectedProduct.ProductModels.Values)
                {
                    this.Models.Add(m);
                }

                if (this.Models.Count > 0)
                {
                    this.SelectedModel = this.Models[0];
                }
                else
                {
                    this.SelectedModel = null;
                }
            }
            else
            {
                this.Models.Clear();
                this.SelectedModel = null;
            }
        }

        public IList<Product> Products { get; set; } = new ObservableCollection<Product>();

        public IList<ProductModel> Models { get; set; } = new ObservableCollection<ProductModel>();

        public int Quantity { get; set; } = 1;
    }
}
