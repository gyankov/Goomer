using Goomer.Data.Models.BaseModels;
using System.Collections.Generic;

namespace Goomer.Data.Models
{
    public class RimWithTire : BaseModel, IRim, ITire
    {
        private ICollection<RimWithTirePicture> pictures;
        public RimWithTire()
        {
            this.pictures = new HashSet<RimWithTirePicture>();
        }
        public int SpeedIndex { get; set; }

        public string WeightIndex { get; set; }

        public double Height { get; set; }

        public int Dot { get; set; }

        public double GrappleMm { get; set; }

        public string Season { get; set; }

        public double SpaceBetweenBolts { get; set; }

        public int NumberOfBolts { get; set; }

        public double CentralHoleSize { get; set; }

        public virtual ICollection<RimWithTirePicture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }
    }
}
