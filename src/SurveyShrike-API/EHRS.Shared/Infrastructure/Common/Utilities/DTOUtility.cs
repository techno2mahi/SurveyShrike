using System;
using System.Collections.Generic;
using System.Reflection;

namespace EHRS.Shared
{
    public static class DTOUtility
    {
        public static void FillAuditInfo(object dto, DateTime createdOn)
        {
            Dictionary<string, PropertyInfo> properties = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo property in dto.GetType().GetProperties())
                properties.Add(property.Name, property);
            
            if ( properties.ContainsKey("CreatedOn"))
            {
                PropertyInfo propertyInfo = properties["CreatedOn"];
                propertyInfo.SetValue(dto, createdOn);
            }
            if (properties.ContainsKey("UpdatedOn"))
            {
                PropertyInfo propertyInfo = properties["UpdatedOn"];
                propertyInfo.SetValue(dto, DateTime.Now);
            }
            if (properties.ContainsKey("IsActive"))
            {
                PropertyInfo propertyInfo = properties["IsActive"];
                propertyInfo.SetValue(dto, true);
            }
            if (properties.ContainsKey("IsDeleted"))
            {
                PropertyInfo propertyInfo = properties["IsDeleted"];
                propertyInfo.SetValue(dto, false);
            }
        }

        public static void FillAuditInfo(object dto)
        {
            FillAuditInfo(dto, DateTime.Now);
        }
    }
}
