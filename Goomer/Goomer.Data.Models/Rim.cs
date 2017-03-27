using Goomer.Data.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [Range(1,2000)]
        public double SpaceBetweenBolts { get; set; }

        [Required]
        [Range(1, 50)]
        public int NumberOfBolts { get; set; }

        [Required]
        [Range(1, 1000)]
        public double CentralHoleSize { get; set; }
        
        public virtual ICollection<RimPicture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }

    }
}
