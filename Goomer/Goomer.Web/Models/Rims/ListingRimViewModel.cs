using Goomer.Data.Models;
using Goomer.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goomer.Web.Models.Rims
{
    public class ListingRimViewModel : IMapFrom<Rim>
    {
        public int Id { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Siting { get; set; }

        public decimal Price { get; set; }

        public bool IsBrandNew { get; set; }

        public ICollection<RimPicture> Pictures { get; set; }
    }
}