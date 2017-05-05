using ProjectManager.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ProjectManager.Common.Providers
{
    public class Validator
    {
        public void Validate<T>(T obj) where T : class
        {
            var errorList = this.GetValidationErrors(obj);

            if (errorList.Count() != 0)
            {
                throw new UserValidationException(errorList.First());
            }
        }

        private IEnumerable<string> GetValidationErrors(object obj)
        {
            Type objectType = obj.GetType();

            PropertyInfo[] objectProperties = objectType.GetProperties();

            Type attributeType = typeof(ValidationAttribute);

            foreach (var property in objectProperties)
            {
                object[] customAttributes = property.GetCustomAttributes(attributeType, inherit: true);

                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;

                    bool isValidProperty = validationAttribute.IsValid(property.GetValue(obj, BindingFlags.GetProperty, null, null, null));

                    if (!isValidProperty)
                    {
                        yield return validationAttribute.ErrorMessage;
                    }
                }
            }
        }
    }
}