using Goomer.Data.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models
{
    public abstract class Item : IAuditInfo, IDeletableEntity
    {
        private ICollection<Picture> pictures;

        public Item()
        {
            this.pictures = new HashSet<Picture>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Siting { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        
        public double Size { get; set; }
        
        public double Width { get; set; }

        public bool IsBrandNew { get; set; }

        public string Description { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Picture> Pictures
        {
            get { return this.pictures; }
            set { this.pictures = value; }
        }
    }
}
