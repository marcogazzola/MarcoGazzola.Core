using System;

namespace MarcoGazzola.Base.Interfaces
{
    public interface IEntity
    {
        string Id { get; set; }
        DateTime? UpdatedOn { get; set; }
        DateTime CreatedOn { get; set; }
    }
}