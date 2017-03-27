using Goomer.Data.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [Range(0, 100)]
        public int SpeedIndex { get; set; }

        [Required]
        [StringLength(20)]
        public string WeightIndex { get; set; }

        [Required]
        [Range(0, 1000)]
        public double Height { get; set; }

        [Required]
        [Range(1000, 9999)]
        public int Dot { get; set; }
        
        [Required]
        [Range(1, 20)]
        public double GrappleMm { get; set; }

        [Required]
        [StringLength(20)]
        public string Season { get; set; }
        
        public virtual ICollection<TirePicture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }
    }
}
