using EHRS.Web.Shared.Models;

namespace EHRS.Web.Shared.Serializers
{
    public interface IJsonFieldsSerializer
    {
        string Serialize(ISerializableObject objectToSerialize, string fields);
    }
}
