using Goomer.Data.Models.BaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Goomer.Data.Models
{
    public class RimWithTire : BaseModel, IRim, ITire
    {
        private ICollection<RimWithTirePicture> pictures;
        public RimWithTire()
        {
            this.pictures = new HashSet<RimWithTirePicture>();
        }

        [Required]
        [Range(0,100)]
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

        [Required]
        [Range(1, 2000)]
        public double SpaceBetweenBolts { get; set; }

        [Required]
        [Range(1, 50)]
        public int NumberOfBolts { get; set; }

        [Required]
        [Range(1, 1000)]
        public double CentralHoleSize { get; set; }

        public virtual ICollection<RimWithTirePicture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }
    }
}
