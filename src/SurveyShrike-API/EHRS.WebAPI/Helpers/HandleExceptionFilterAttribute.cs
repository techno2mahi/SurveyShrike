﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace EHRS.WebAPI.Helpers
{
    /// <summary>
    /// The Custom Exception Filter
    /// </summary>
    public class HandleExceptionFilterAttribute : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //Check the Exception Type

            if (actionExecutedContext.Exception is HandleException)
            {
                //The Response Message Set by the Action During Ececution
                var res = actionExecutedContext.Exception.Message;

                //Define the Response Message
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(res),
                    ReasonPhrase = res
                };


                //Create the Error Response

                actionExecutedContext.Response = response;
            }
        }
    }
}