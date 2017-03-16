using System;

namespace Goomer.Data.Models.BaseModels
{
    public interface IEntityWithCreator
    {
        Guid UserId { get; set; }
    }
}
