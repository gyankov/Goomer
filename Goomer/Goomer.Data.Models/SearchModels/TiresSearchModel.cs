using System.ComponentModel.DataAnnotations;

namespace Goomer.Data.Models.SearchModels
{
    public class TiresSearchModel
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        [Range(1000, 9999, ErrorMessage = "Дот може да е между 1000 и 9999.")]
        public int? DotFrom { get; set; }

        public string Siting { get; set; }

        public int? QuantityFrom { get; set; }

        public double? Width { get; set; }

        public double? Height { get; set; }

        public double? Size { get; set; }

        public bool OnlyBrandNew { get; set; }

        public int SpeedIndexFrom { get; set; }

        public string WeightIndex { get; set; }

        public double GrappleFrom { get; set; }

        public string Season { get; set; }
        
        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }
    }
}
