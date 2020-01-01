using System.Collections.Generic;

namespace EHRS.Web.Shared.Helpers
{
    public interface IJsonHelper
    {
        Dictionary<string, object> DeserializeToDictionary(string json);
    }
}