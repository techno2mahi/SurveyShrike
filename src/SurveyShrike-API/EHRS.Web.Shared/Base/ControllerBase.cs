namespace EHRS.Web.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;
    using EHRS.Shared;

    /// <summary>
    /// Represents abstract base class for controller
    /// </summary>
    public abstract class BaseController : Controller
    {
        #region "Constants"

        private const string ErrorController = "Error";
        private const string ErrorControllerAction = "Index";
        private const string Controller = "controller";

        private const string PrintLayout = "_PrintLayout";
        private const string PdfExtension = ".pdf";
        private const string ContentLengthHeader = "content-length";
        private const string ContentDispositionHeader = "content-disposition";
        private const string ContentDispositionValue = "inline; filename=";
        private const string PdfMimeType = "application/pdf";

        #endregion

        public string ControllerName
        {
            get
            {
                return this.RouteData.Values[Controller].ToString();
            }
        }
        /// <summary>
        /// Handles validation failure
        /// </summary>
        /// <param name="result"></param>
        protected bool HandleValidationFailure<T>(OperationResult<T> result)
        {
            bool retVal = false;

            if (result.HasValidationFailed() && result.ValidationResult != null)
            {
                retVal = true;

                foreach (EHRSValidationFailure error in result.ValidationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return retVal;
        }

        /// <summary>
        /// Returns the error result
        /// </summary>
        /// <param name="message"></param>
        /// <param name="stackTrace"></param>
        /// <returns></returns>
        protected ActionResult HttpGetErrorResult(string message)
        {
            ActionResult retVal = null;

            if (!Request.IsAjaxRequest())
            {
                SessionStateManager<ErrorState>.Data.ErrorMessage = message;
                SessionStateManager<ErrorState>.Data.StackTrace = string.Empty;

                retVal = RedirectToAction(ErrorControllerAction, ErrorController);
            }

            return retVal;
        }

        /// <summary>
        /// The PDF view.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /*protected static PDFActionResult PDFView(string viewName, object model)
        {
            return new PDFActionResult(viewName, model);
        }*/

        /// <summary>
        /// POB Report.
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult ExportReportHTMLToPDF(string htmlContent)
        {
            ActionResult retVal = null;

            /*try
            {
                var stringWriter = new StringWriter();

                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, PrintLayout);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, stringWriter);
                viewResult.View.Render(viewContext, stringWriter);

                string layoutHtml = stringWriter.GetStringBuilder().ToString();
                stringWriter.GetStringBuilder().Clear();

                var placeholder = new Dictionary<string, string>();
                placeholder.Add(AppConstants.Common.PrintBodyPlaceholder, htmlContent);

                string completeHtml = layoutHtml.Inject(placeholder, AppConstants.Delimiters.StartDelimiter, AppConstants.Delimiters.EndDelimiter);
                byte[] htmlBytes = new NReco.PdfGenerator.HtmlToPdfConverter().GeneratePdf(completeHtml);

                string fileName = Guid.NewGuid() + PdfExtension;
                var fileStream = new FileStream(Path.Combine(AppConstants.ConfigurationKeys.ExportedReportsPath, fileName), 
                                                FileMode.Create, FileAccess.Write);
                fileStream.Write(htmlBytes, 0, htmlBytes.Length);
                fileStream.Close();

                retVal = OperationResult<string>.CreateSuccessResult(fileName.Replace(PdfExtension, string.Empty)).ToJsonResult();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<string>.CreateFailureResult("Failed to export data.").ToJsonResult();
            }*/

            return retVal;
        }

        /// <summary>
        /// Downloads the exported report
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ActionResult DownloadExportedReport(string fileName)
        {
            HttpResponseBase response = HttpContext.Response;

            response.Clear();
            response.ContentType = PdfMimeType;
            response.AppendHeader(ContentDispositionHeader, ContentDispositionValue + fileName + PdfExtension);

            byte[] pdfBytes = System.IO.File.ReadAllBytes(Path.Combine(AppConstants.ConfigurationKeys.ExportedReportsPath, fileName + PdfExtension));
            response.AddHeader(ContentLengthHeader, pdfBytes.Length.ToString());
            response.BinaryWrite(pdfBytes);

            response.Flush();
            response.End();

            return new EmptyResult();
        }
    }
}
