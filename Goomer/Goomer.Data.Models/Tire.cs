using Goomer.Data.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models
{
    public class Tire : BaseModel, ITire
    {
        private ICollection<TirePicture> pictures;
        public Tire()
        {
            this.pictures = new HashSet<TirePicture>();
        }
        public string SpeedIndex { get; set; }

        public string WeightIndex { get; set; }

        public double Height { get; set; }
        
        public int Dot { get; set; }

        public double GrappleMm { get; set; }

        public string Season { get; set; }
        
        public virtual ICollection<TirePicture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }
    }
}
