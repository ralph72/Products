using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Models
{
    public class ItemList
    {
        private IDictionary<string, Part> parts = new Dictionary<string, Part>(StringComparer.CurrentCultureIgnoreCase);

        public ItemList()
        { }

        public void SaveToDisk()
        {
            OrderedProducts orderedProducts = Repositories.OrderedProducts;

            foreach(OrderedProductUI product in orderedProducts.Products)
            {                
                foreach(Part p in product.SelectedModel.Parts)
                {
                    if(parts.ContainsKey(p.PartID))
                    {
                        parts[p.PartID].Quantity += p.Quantity * product.Quantity;
                    }
                    else
                    {
                        parts[p.PartID] = p.Clone();
                        parts[p.PartID].Quantity *= product.Quantity;
                    }
                }
            }

            using (TextWriter textWriter = new StringWriter())
            {
                using (CsvWriter writer = new CsvWriter(textWriter))
                {
                    writer.WriteRecords(this.parts.Values);

                    try
                    {
                        File.WriteAllText("NewOrder.csv", textWriter.ToString());
                        System.Diagnostics.Process.Start("NewOrder.csv");
                    }
                    catch
                    {
                        string text = Guid.NewGuid().ToString();
                        File.WriteAllText(text + ".csv", textWriter.ToString());
                        System.Diagnostics.Process.Start(text + ".csv");
                    }
                }
            }
        }
    }
}
