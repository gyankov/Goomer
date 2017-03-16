using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        public string Url { get; set; }

        public virtual Item Item { get; set; }
    }
}
