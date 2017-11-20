using Products.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Products
{
    /// <summary>
    /// Interaction logic for ModelInfoControl.xaml
    /// </summary>
    public partial class ModelInfoControl : UserControl
    {


        public ModelInfoControl()
        {
            InitializeComponent();
        }

        public ModelInfoControl(ProductUI model) : this()
        {
            this.DataContext = model;
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.BindedModel != null)
            {
                this.BindedModel.Name = this.txtName.Text;
            }
        }

        private void TxtCSVContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtCSVContent.Text))
            {
            }
            else
            {
                try
                {
                    this.BindedModel.CSVContent = this.txtCSVContent.Text;
                }
                catch
                {
                    MessageBox.Show("Invalid CSV");
                }
            }
        }

        private ProductUI BindedModel
        {
            get
            {
                return (ProductUI)this.DataContext;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public String ModelName
        {
            get { return (String)GetValue(ModelNameProperty); }
            set { SetValue(ModelNameProperty, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty ModelNameProperty =
            DependencyProperty.Register("ModelName", typeof(string),
              typeof(ModelInfoControl), new PropertyMetadata(""));



        /// <summary>
        /// Gets or sets the Value which is being displayed
        /// </summary>
        public object ModelCSVContent
        {
            get { return (object)GetValue(CSVContentProperty); }
            set { SetValue(CSVContentProperty, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty CSVContentProperty =
            DependencyProperty.Register("ModelCSVContent", typeof(object),
              typeof(ModelInfoControl), new PropertyMetadata(null));

        public ProductUI ProductModel
        {
            get
            {
                return this.BindedModel;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Repositories.Products.Products.Remove(this.BindedModel.Name);
            Repositories.ProductsUI.Models.Remove(this.BindedModel);
            Repositories.Products.Save();
            this.DataContext = new ProductUI();
            MessageBox.Show("Removed");
        }
    }
}
