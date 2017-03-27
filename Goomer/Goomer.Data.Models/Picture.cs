using Goomer.Data.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goomer.Data.Models
{
    public class Picture : IAuditInfo, IDeletableEntity
    {
        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
