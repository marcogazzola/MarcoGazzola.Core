using MarcoGazzola.Base.Interfaces;
using System;

namespace MarcoGazzola.Base
{
    public class InsertOperationResult
         : OperationResult
         , IInsertOperationResult
    {

        // PRIVATE MEMBERs
        private Object _CreatedEntityId;

        #region " CTORs "

        // CTOR
        public InsertOperationResult(Object createdEntityId, Boolean genericMeaning)
            : base(genericMeaning)
        {
            this._CreatedEntityId = createdEntityId;
        }

        // CTOR
        public InsertOperationResult(Object createdEntityId, Boolean genericMeaning, String description)
            : this(createdEntityId, genericMeaning)
        {
            this._Description = description;
        }

        // CTOR
        public InsertOperationResult(Object createdEntityId, Boolean genericMeaning, String description, String[] warnings)
            : this(createdEntityId, genericMeaning, description)
        {
            this._Warnings = warnings;
        }

        #endregion

        #region IInsertOperationResult Members

        // CREATED ENTITY ID
        public Object CreatedEntityId
        {
            get { return this._CreatedEntityId; }
        }

        #endregion

    }
}