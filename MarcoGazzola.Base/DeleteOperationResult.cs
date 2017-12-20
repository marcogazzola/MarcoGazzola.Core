using MarcoGazzola.Base.Interfaces;
using System;

namespace MarcoGazzola.Base
{
    public class DeleteOperationResult
        : OperationResult
        , IDeleteOperationResult
    {

        #region " CTORs "

        // CTOR
        public DeleteOperationResult(Boolean genericMeaning)
            : base(genericMeaning)
        {
        }

        // CTOR
        public DeleteOperationResult(Boolean genericMeaning, String description)
            : this(genericMeaning)
        {
            this._Description = description;
        }

        // CTOR
        public DeleteOperationResult(Boolean genericMeaning, String description, String[] warnings)
            : this(genericMeaning, description)
        {
            this._Warnings = warnings;
        }

        #endregion

    }
}