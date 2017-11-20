using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Models
{
    public class Part
    {
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; } = 1;
        public string PartID { get; set; } = string.Empty;

        public Part Clone()
        {
            return new Part() { Description = this.Description, PartID = this.PartID, Quantity = this.Quantity };
        }
    }
}
