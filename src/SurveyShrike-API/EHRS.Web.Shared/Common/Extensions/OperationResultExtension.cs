using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using EHRS.Shared;

namespace EHRS.Web.Shared
{
    public static class OperationResultExtension
    {
        /// <summary>
        /// Method to convert operation result to JSON operation result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operationResult"></param>
        /// <returns></returns>
        public static JsonResult ToJsonOperationResult<T>(this OperationResult<T> operationResult)
        {
            JsonResult retVal = null;
            
            EHRSValidationResult validationResult = null;
            string message = string.Empty;

            if (!operationResult.IsValid())
            {
                if (operationResult.HasValidationFailed())
                {
                    validationResult = operationResult.ValidationResult;
                    message = operationResult.Message;
                }
                else if (operationResult.HasExceptionOccurred())
                {
                    SessionStateManager<ErrorState>.Data.ErrorMessage = operationResult.Message;
                    SessionStateManager<ErrorState>.Data.StackTrace = operationResult.StackTrace;
                }
            }
            else
            {
                message = operationResult.Message;
            }

            JsonOperationResult<T> jsonOperationResult = new JsonOperationResult<T>(operationResult.Data, operationResult.ResultType, 
                                                                                    validationResult, message);
            retVal = new JsonResult()
            {
                Data = jsonOperationResult,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            return retVal;
        }

    }
}
