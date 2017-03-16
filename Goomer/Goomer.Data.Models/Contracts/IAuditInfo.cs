using System;

namespace Goomer.Data.Models.BaseModels
{
    public interface IAuditInfo
    {
        DateTime? CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
