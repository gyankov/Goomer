using Goomer.Data.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models
{
    public class Rim : BaseModel, IRim
    {
        private ICollection<RimPicture> pictures;
        public Rim()
        {
            this.pictures = new HashSet<RimPicture>();
        }

        public double SpaceBetweenBolts { get; set; }

        public int NumberOfBolts { get; set; }

        public double CentralHoleSize { get; set; }
        
        public virtual ICollection<RimPicture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }

    }
}
