using DataAccess;
using Products.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class ProductUI : INotifyPropertyChanged
    {
        private string name = "";
        private string csvContent = "";        

        public ProductUI()
        { }

        public ProductUI(string name, string csvContent)
        {
            this.Name = name;
            this.CSVContent = csvContent;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Save()
        {
            if (String.IsNullOrEmpty(this.csvContent) == false)
            {

                DataTable dt = DataTable.New.ReadFromString(this.csvContent);
                
                Product product = new Product(this.name);

                foreach (string name in dt.ColumnNames.Where(s => s.ToUpper() != "ITEM"))
                {
                    product.ProductModels.Add(name, new ProductModel(name));
                }

                foreach (Row r in dt.Rows)
                {
                    string itemDescription = r["Item"];
                    int quantity = 0;
                    ParseDescription(itemDescription, out itemDescription, out quantity);
                    if (string.IsNullOrEmpty(itemDescription) == false)
                    {
                        foreach (string name in r.ColumnNames.Where(s => s.ToUpper() != "ITEM"))
                        {
                            Part part = new Part();
                            part.Description = itemDescription;
                            string desc2;
                            int q2;
                            ParseDescription(part.Description, out desc2, out q2);
                            part.PartID = string.IsNullOrEmpty(r[name]) ? desc2 : r[name];
                            part.Description = desc2;
                            part.Quantity = quantity * q2;
                            product.ProductModels[name].Parts.Add(part);
                        }
                    }
                }

                Repositories.Products.Products[product.Name] = product;
                Repositories.Products.Save();
            }
        }

        private void ParseDescription(string description, out string d, out int quantity)
        {
            description = description.Trim();
            if (description.EndsWith(")"))
            {
                d = description.Substring(0, description.Length - 3);
                string val = description[description.Length - 2].ToString();

                if (int.TryParse(val, out quantity) == false)
                {
                    quantity = 1;
                }
            }
            else
            {
                d = description;
                quantity = 1;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }

        public string CSVContent
        {
            get
            {
                return this.csvContent;
            }
            set
            {
                this.csvContent = value;
                OnPropertyChanged("CSVContent");

                Save();
            }
        }
    }
}
