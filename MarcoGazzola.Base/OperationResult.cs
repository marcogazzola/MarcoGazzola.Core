using MarcoGazzola.Base.Interfaces;
using System;

namespace MarcoGazzola.Base
{
    public class OperationResult
        : IOperationResult
    {

        // PRIVATE MEMBERs
        protected Boolean _GenericMeaning = true;
        protected String[] _Warnings = new String[] { };
        protected String _Description = String.Empty;

        #region " CTORs "

        // CTOR
        public OperationResult(Boolean genericMeaning)
        {
            this._GenericMeaning = genericMeaning;
        }

        // CTOR
        public OperationResult(Boolean genericMeaning, String description)
            : this(genericMeaning)
        {
            this._Description = description;
        }

        // CTOR
        public OperationResult(Boolean genericMeaning, String description, String[] warnings)
            : this(genericMeaning, description)
        {
            this._Warnings = warnings;
        }

        #endregion

        #region IOperationResult Members

        public Boolean GenericMeaning
        {
            get { return this._GenericMeaning; }
            set { this._GenericMeaning = value; }
        }

        public String[] Warnings
        {
            get { return this._Warnings; }
            set { this._Warnings = value; }
        }

        public String Description
        {
            get { return this._Description; }
            set { this._Description = value; }
        }

        #endregion

    }
}