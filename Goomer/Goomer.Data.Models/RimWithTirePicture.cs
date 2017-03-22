using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models
{
    public class RimWithTirePicture : Picture
    {
        public virtual int RimWithTireId { get; set; }
        public virtual RimWithTire RimWithTire { get; set; }
    }
}
