using Goomer.Data.Models;
using Goomer.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goomer.Web.Models.Home
{
    public class TireViewModel: IMapFrom<Tire>
    {
        public int Id { get; set; }

        public  ICollection<TirePicture> Pictures { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

    }
}