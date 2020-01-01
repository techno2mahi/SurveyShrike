namespace EHRS.Web.Shared
{
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;

    public static class AjaxExtensions
    {
        #region "Constants"

        private const string CommonFormSubmitSuccessCallback =
            "ehrsCommon.postFormSuccess(data, status, xhr, ##successCallback##, ##failureCallback##, ##validationCallback##);";
        private const string SuccessCallbackPlaceholder = "##successCallback##";
        private const string FailureCallbackPlaceholder = "##failureCallback##";
        private const string ValidationCallbackPlaceholder = "##validationCallback##";

        private const string CommonFormSubmitFailureCallback =
            "ehrsCommon.handleError";

        private const string Undefined = "undefined";

        #endregion "Constants"

        #region "Methods"

        public static MvcForm BeginPostForm(this AjaxHelper ajaxHelper, 
                                            string url, object routeValues, string beginCallback, 
                                            string successCallback, string failureCallback, string validationCallback, object htmlAttributes)
        {
            MvcForm retVal = null;

            beginCallback = HandledNullOrEmptyCallbacks(beginCallback);
            successCallback = HandledNullOrEmptyCallbacks(successCallback);
            failureCallback = HandledNullOrEmptyCallbacks(failureCallback);
            validationCallback = HandledNullOrEmptyCallbacks(validationCallback);

            AjaxOptions ajaxOptions = new AjaxOptions()
            {
                Url = url,
                HttpMethod = "POST",
                OnBegin = beginCallback,
                OnSuccess = CommonFormSubmitSuccessCallback.Replace(
                            SuccessCallbackPlaceholder, successCallback).Replace(
                            FailureCallbackPlaceholder, failureCallback).Replace(ValidationCallbackPlaceholder, validationCallback),
                OnFailure = CommonFormSubmitFailureCallback
            };

            retVal = ajaxHelper.BeginForm(string.Empty, routeValues, ajaxOptions, htmlAttributes);

            return retVal;
        }

        #endregion "Methods"

        #region "Private Methods"

        /// <summary>
        /// Handles null or empty callbacks.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        private static string HandledNullOrEmptyCallbacks(string callback)
        {
            string retVal = string.Empty;
            retVal = !string.IsNullOrEmpty(callback) ? callback : Undefined;

            return retVal;
        }

        #endregion
    }
}
