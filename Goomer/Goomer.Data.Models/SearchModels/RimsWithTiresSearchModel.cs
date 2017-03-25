using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.SearchModels
{
    public class RimsWithTiresSearchModel
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

        public double? Height { get; set; }

        public int? SpeedIndexFrom { get; set; }

        public string WeightIndex { get; set; }

        public double? GrappleFrom { get; set; }

        public string Season { get; set; }

        [Range(1000, 9999, ErrorMessage = "Дот може да е между 1000 и 9999.")]
        public int? DotFrom { get; set; }
    }
}
