namespace EHRS.Web.Shared
{
    using System;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// The url helper extensions.
    /// </summary>
    public static class UrlHelperExtensions
    {
        #region "Constants"

        /// <summary>
        /// Constant to define client route name
        /// </summary>
        private const string Client = "ClientRoute";

        /// <summary>
        /// Constant name action
        /// </summary>
        private const string Action = "action";

        /// <summary>
        /// Constant name controller
        /// </summary>
        private const string Controller = "controller";

        /// <summary>
        /// Constant name client id used in client router
        /// </summary>
        private const string ClientId = "ClientId";

        #endregion

        /// <summary>
        /// Url helper
        /// </summary>
        /// <param name="url"></param>
        /// <param name="actionName">action name</param>
        /// <param name="controllerName"> controller name</param>
        /// <param name="routeValues">route Values</param>
        /// <returns>Smart URL</returns>
        public static string SmartAction(this UrlHelper url, string actionName, string controllerName, object routeValues)
        {
            string result = string.Empty;
            result = url.Action(actionName, controllerName, routeValues);
          /*  if (PortalUtility.IsClientPortalSelected)
            {
                if (routeValues == null)
                {
                    result = url.RouteUrl(
                        Client,
                        new
                        {
                            action = actionName,
                            controller = controllerName,
                            ClientId = PortalUtility.SelectedClientId
                        });
                }
                else
                {
                    RouteValueDictionary routeValueDictionary = new RouteValueDictionary();

                    routeValueDictionary.Add(Action, actionName);
                    routeValueDictionary.Add(Controller, controllerName);
                    routeValueDictionary.Add(ClientId, PortalUtility.SelectedClientId);

                    foreach (PropertyInfo property in routeValues.GetType().GetProperties())
                    {
                        if (string.Compare(property.Name, Action, StringComparison.OrdinalIgnoreCase) != 0 &&
                            string.Compare(property.Name, Controller, StringComparison.OrdinalIgnoreCase) != 0 &&
                            string.Compare(property.Name, ClientId, StringComparison.OrdinalIgnoreCase) != 0)
                        {
                            routeValueDictionary.Add(property.Name, property.GetValue(routeValues, null));
                        }
                    }

                    result = url.RouteUrl(Client, routeValueDictionary);
                }
            }
            else
            {
                result = url.Action(actionName, controllerName, routeValues);
            }*/

            return result;
        }

        /// <summary>
        /// Url helper
        /// </summary>
        /// <param name="url"></param>
        /// <param name="actionName"></param>
        /// <param name="controllerName"></param>
        /// <returns>Smart url</returns>
        public static string SmartAction(this UrlHelper url, string actionName, string controllerName)
        {
            string result = SmartAction(url, actionName, controllerName, null);
            return result;
        }

        /// <summary>
        /// Gets the absolute URL
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <returns></returns>
        public static string AbsoluteUrl(this UrlHelper url, string relativeUrl)
        {
            string applicationPath = string.Empty;

            //Getting the current context of HTTP request
            HttpContext context = HttpContext.Current;

            //Checking the current context content
            if (context != null)
            {
                //Formatting the fully qualified website url/name
                applicationPath = string.Format("{0}://{1}{2}{3}",
                  context.Request.Url.Scheme,
                  context.Request.Url.Host,
                  context.Request.Url.Port == 80
                    ? string.Empty : ":" + context.Request.Url.Port,
                  context.Request.ApplicationPath);
            }
            if (!applicationPath.EndsWith("/"))
            {
                applicationPath += "/";
            }
            return string.Concat(applicationPath, relativeUrl);
        }
    }
}
