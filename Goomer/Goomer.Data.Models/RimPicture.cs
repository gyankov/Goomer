using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models
{
    public class RimPicture : Picture
    {
        public virtual int RimId { get; set; }
        public virtual Rim Rim { get; set; }
    }
}
