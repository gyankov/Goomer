﻿using Goomer.Data.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models
{
    public class RimWithTire : Item, IRim, ITire
    {
        public string SpeedIndex { get; set; }

        public string WeightIndex { get; set; }

        public double Height { get; set; }

        public DateTime? Dot { get; set; }

        public double GrappleMm { get; set; }

        public string Season { get; set; }

        public double SpaceBetweenBolts { get; set; }

        public int NumberOfBolts { get; set; }

        public double CentralHoleSize { get; set; }
    }
}