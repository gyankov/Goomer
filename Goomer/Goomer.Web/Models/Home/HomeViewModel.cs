using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goomer.Web.Models.Home
{
    public class HomeViewModel
    {
        IEnumerable<TireViewModel> Tires { get; set; }
        IEnumerable<RimViewModel> Rims { get; set; }
        IEnumerable<RimWithTireViewModel> RimsWithTires { get; set; }

    }
}