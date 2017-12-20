using MarcoGazzola.Base;
using MarcoGazzola.Base.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarcoGazzola
{
    public static class Extensions
    {
        public static IOperationResult ToOperationResult(this DeleteResult result)
        {
            return result == null ? null : new DeleteOperationResult(true);
        }
        public static IOperationResult ToOperationResult(this ReplaceOneResult result)
        {
            return result == null ? null : new UpdateOperationResult(true);
        }
        public static IOperationResult MongoException(this Exception ex)
        {
            if (ex is MongoAuthenticationException)
                return new OperationResult(false, $"Authentication exception: {ex.Message}");
            else if (ex is MongoConnectionException)
                return new OperationResult(false, $"Generic connection exception: {ex.Message}");
            else
                return new OperationResult(false, $"Generic exception: {ex.Message}");
        }
    }
}
