using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models
{
    public class TirePicture : Picture
    {
        public virtual int TireId { get; set; }
        public virtual Tire Tire { get; set; }
    }
}
