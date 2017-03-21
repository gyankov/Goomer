using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goomer.Web.Models.Home
{
    public class HomeViewModel
    {
        public IEnumerable<TireViewModel> Tires { get; set; }
        public IEnumerable<RimViewModel> Rims { get; set; }
        public IEnumerable<RimWithTireViewModel> RimsWithTires { get; set; }

    }
}