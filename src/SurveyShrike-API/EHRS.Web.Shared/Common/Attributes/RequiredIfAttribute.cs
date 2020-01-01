using System;

namespace EHRS.Web.Shared
{
    using System.ComponentModel.DataAnnotations;

    [AttributeUsageAttribute(AttributeTargets.Property, Inherited = true)]
    public sealed class RequiredIfAttribute : RequiredAttribute
    {
        public String PropertyName { get; private set; }
        public Object DesiredValue { get; private set; }

        public RequiredIfAttribute(String propertyName, Object desiredvalue)
        {
            PropertyName = propertyName;
            DesiredValue = desiredvalue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult retVal = ValidationResult.Success;

            Type type = validationContext.ObjectInstance.GetType();
            Object propertyValue = type.GetProperty(PropertyName).GetValue(validationContext.ObjectInstance, null);

            if (propertyValue.ToString() == DesiredValue.ToString())
            {
                retVal = base.IsValid(value, validationContext);
            }

            return retVal;
        }
    }
}
