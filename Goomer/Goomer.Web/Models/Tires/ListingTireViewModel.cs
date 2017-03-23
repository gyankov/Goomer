using Goomer.Data.Models;
using Goomer.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;

namespace Goomer.Web.Models.Tires
{
    public class ListingTireViewModel : IMapFrom<Tire>
    {
        public int Id { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Siting { get; set; }

        public decimal Price { get; set; }

        public bool IsBrandNew { get; set; }

        public  ICollection<TirePicture> Pictures { get; set; }

    }
}