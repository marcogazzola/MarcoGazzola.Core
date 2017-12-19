using System;

namespace MarcoGazzola.MongoDB.Interfaces
{
    public interface IEntity
    {
        string Id { get; set; }
        DateTime? UpdatedOn { get; set; }
        DateTime CreatedOn { get; set; }
    }
}