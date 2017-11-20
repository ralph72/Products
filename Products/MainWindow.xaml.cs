using Products.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Products
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.tabModels.ItemsSource = Repositories.ProductsUI.Models;
        }

        private void tabModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                ProductUI p = (ProductUI)e.AddedItems[0];
                if (p.Name == ProductsUI.ADD_TAG_TEXT)
                {
                    p.Name = ProductsUI.NEW_TAG_TEXT;
                    ProductUI p2 = new ProductUI(ProductsUI.ADD_TAG_TEXT, "");
                    Repositories.ProductsUI.Models.Add(p2);
                }
            }
        }

        private void AddNewPlaceholderTab()
        {
        }

        private TabItem GetTabItemByModel(ProductModel model)
        {
            return this.tabModels.Items.Cast<TabItem>().Where(item => item.Tag == model).ToList<TabItem>()[0];
        }
        

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            this.orderForm.Update();
            this.tabModels.Visibility = Visibility.Collapsed;
            this.orderForm.Visibility = Visibility.Visible;
        }

        private void BtnConfig_Click(object sender, RoutedEventArgs e)
        {
            this.tabModels.Visibility = Visibility.Visible;
            this.orderForm.Visibility = Visibility.Collapsed;
        }

        private void BtnOpenInExcel_Click(object sender, RoutedEventArgs e)
        {
            ItemList i = new ItemList();
            i.SaveToDisk();
        }
    }
}
