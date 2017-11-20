using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Products
{
    /// <summary>
    /// Interaction logic for OrderForm.xaml
    /// </summary>
    public partial class OrderFormControl : UserControl
    {
        public OrderFormControl()
        {            
            InitializeComponent();

            this.DataContext = new OrderedProductUI();
            
        }

        private OrderedProductUI BindedModel
        {
            get
            {
                return (OrderedProductUI)this.DataContext;
            }
        }

        private void comboProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindedModel.UpdateModels();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Repositories.OrderedProducts.Products.Add(this.BindedModel);
            this.DataContext = new OrderedProductUI();
            MessageBox.Show("Added.");
        }

        public void Update()
        {
            BindedModel.Update();
        }
    }
}
