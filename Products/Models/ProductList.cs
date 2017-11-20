using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Models
{
    public class ProductList
    {
        public IDictionary<string, Product> Products { get; set; } = new Dictionary<string, Product>(StringComparer.CurrentCultureIgnoreCase);

        public ProductList()
        {
            this.Load();
        }

        public void Load()
        {
            if (File.Exists("products.json"))
            {
                this.Products = JsonConvert.DeserializeObject<Dictionary<string, Product>>(File.ReadAllText("products.json")).Where(s => s.Value.Name.Contains("<") == false).ToDictionary(v=>v.Key, v=>v.Value);
            }
        }

        public void Save()
        {
            if (File.Exists("products.json"))
            {
                File.Delete("products.json");
            }
            string json = JsonConvert.SerializeObject(this.Products.Where(s => s.Value.Name.Contains("<") == false).ToDictionary(v => v.Key, v => v.Value));
            File.WriteAllText("products.json", json);
        }
    }
}
