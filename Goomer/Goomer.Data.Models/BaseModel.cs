using Goomer.Data.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Goomer.Data.Models
{
    public class BaseModel : IAuditInfo, IDeletableEntity
    {
        public BaseModel()
        {
        }

        [Key]
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Brand { get; set; }


        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Model { get; set; }


        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Siting { get; set; }

        [Required]
        [Range(1,1000)]
        public int Quantity { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public decimal Price { get; set; }
        
        [Required]
        [Range(1,30)]
        public double Size { get; set; }

        [Required]
        [Range(1, 400)]
        public double Width { get; set; }

        [Required]
        public bool IsBrandNew { get; set; }

        [StringLength(300,MinimumLength =1)]
        public string Description { get; set; }
        
        public virtual User Owner { get; set; }     
              
    }
}
