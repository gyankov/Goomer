using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models.BaseModels
{
    public interface IRim
    {
        double SpaceBetweenBolts { get; set; }

        int NumberOfBolts { get; set; }

        double CentralHoleSize { get; set; }
    }
}
