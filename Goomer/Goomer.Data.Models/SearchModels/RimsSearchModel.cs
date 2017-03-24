using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.SearchModels
{
    public class RimsSearchModel
    {
        public string Brand { get; set; }
        
        public string Model { get; set; }
        
        public string Siting { get; set; }

        public int? QuantityFrom { get; set; }

        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }
        
        public double? Size { get; set; }
        
        public double? Width { get; set; }
        
        public double? SpaceBetweenBolts { get; set; }
        
        public int? NumberOfBolts { get; set; }
        
        public double? CentralHoleSize { get; set; }

        public bool OnlyBrandNew { get; set; }
    }
}
