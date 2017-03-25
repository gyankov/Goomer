using Goomer.Data.Models;
using Goomer.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goomer.Web.Models.RimsWithTires
{
    public class RimWithTireAdViewModel : IMapFrom<RimWithTire>
    {
        public DateTime? ModifiedOn { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Siting { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public double Size { get; set; }

        public double Width { get; set; }

        public bool IsBrandNew { get; set; }

        public string Description { get; set; }

        public double Height { get; set; }

        public int Dot { get; set; }

        public double GrappleMm { get; set; }

        public string Season { get; set; }

        public double SpaceBetweenBolts { get; set; }

        public int NumberOfBolts { get; set; }

        public double CentralHoleSize { get; set; }

        public ICollection<RimWithTirePicture> Pictures { get; set; }
    }
}