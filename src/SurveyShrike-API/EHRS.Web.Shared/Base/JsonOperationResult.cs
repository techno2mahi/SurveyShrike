using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using EHRS.Shared;

namespace EHRS.Web.Shared
{
    [Serializable]
    public class JsonOperationResult<T>
    {
        #region Nested Enum

        /// <summary>
        /// Operation Result for JSON results
        /// </summary>
        public enum JsonOperationResultType
        {
            Success = 0,
            Failure = 1,
            Error = 2,
            SessionTimedOut = 3
        }

        #endregion

        #region "Private Properties"

        private T _data;

        private JsonOperationResultType _resultType;

        private EHRSValidationResult _validationResult;

        private string _message;

        #endregion

        #region "Public Properties"

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public T Data
        {
            get
            {
                return _data;
            }
        }

        /// <summary>
        /// Gets or sets the type of the result.
        /// </summary>
        /// <value>The type of the result.</value>
        public string ResultType
        {
            get
            {
                return Enum.GetName(typeof(JsonOperationResultType), _resultType).ToLowerInvariant();
            }
        }

        /// <summary>
        /// Gets or sets the ValidationResult.
        /// </summary>
        /// <value>The ValidationResult.</value>
        public EHRSValidationResult ValidationResult
        {
            get
            {
                return _validationResult;
            }
        }

        /// <summary>
        /// Gets or sets the Message.
        /// </summary>
        /// <value>The Message.</value>
        public string Message
        {
            get
            {
                return _message;
            }
        }

        #endregion

        #region "Constructor"

        public JsonOperationResult(T data, OperationResultType resultType, 
                                   EHRSValidationResult validationResult, string message)
        {
            this._data = data;

            switch (resultType)
            {
                case OperationResultType.Success:
                    this._resultType = JsonOperationResultType.Success;
                    break;
                case OperationResultType.Failure:
                    this._resultType = JsonOperationResultType.Failure;
                    break;
                case OperationResultType.Error:
                    this._resultType = JsonOperationResultType.Error;
                    break;
                case OperationResultType.SessionTimedOut:
                    this._resultType = JsonOperationResultType.SessionTimedOut;
                    break;
            }

            this._validationResult = validationResult;
            this._message = message;
        }
    
        #endregion
    }
}
