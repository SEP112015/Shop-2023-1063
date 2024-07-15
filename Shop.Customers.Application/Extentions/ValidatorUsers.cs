using Shop.Customers.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers.Application.Extentions
{
    public  class ValidatorUsers<T>
    {
        public static ServiceResult Validate(T entity, int maxLength = 0)
        {
            ServiceResult result = new ServiceResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = $"La entidad de tipo {typeof(T).Name} no puede ser nula";
                return result;
            }

            var properties = typeof(T).GetProperties();
            var hasErrors = false;

            foreach (var property in properties)
            {
                var value = property.GetValue(entity);
                var propertyName = property.Name;

                if (value is string && maxLength > 0 && ((string)value).Length > maxLength)
                {
                    hasErrors = true;
                    result.Message += $"El valor de la propiedad '{propertyName}' de la entidad " +
                        $"{typeof(T).Name} excede la longitud máxima de {maxLength} caracteres.\n";
                }
            }

            result.Success = !hasErrors;
            return result;
        }

    }
}
