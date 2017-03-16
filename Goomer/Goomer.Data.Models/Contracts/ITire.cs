using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.BaseModels
{
    public interface ITire
    {
        string SpeedIndex { get; set; }

        string WeightIndex { get; set; }

        double Height { get; set; }

        DateTime? Dot { get; set; }

        double GrappleMm { get; set; }

        string Season { get; set; }
    }
}
