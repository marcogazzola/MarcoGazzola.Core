using System;

namespace MarcoGazzola.Base.Interfaces
{
    public interface IOperationResult
    {
        Boolean GenericMeaning { get; set; }
        String[] Warnings { get; set; }
        String Description { get; set; }
    }

    public interface IUpdateOperationResult : IOperationResult
    {
        // EMPTY
    }

    public interface IInsertOperationResult : IOperationResult
    {
        object CreatedEntityId { get; }
    }

    public interface IDeleteOperationResult : IOperationResult
    {
        // EMPTY
    }

    public interface IBulkInsertOperationResult : IOperationResult
    {
        Int64 RowsEffected { get; }
    }
}