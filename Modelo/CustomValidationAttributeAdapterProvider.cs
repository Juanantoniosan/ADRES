using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace PruebaAdres.Modelo
{
    public class CustomValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider baseProvider =
            new ValidationAttributeAdapterProvider();

        public IAttributeAdapter? GetAttributeAdapter(
            ValidationAttribute attribute, IStringLocalizer? stringLocalizer)
        {
            string nombre = ((System.Type)attribute.TypeId).Name;

            if (nombre == "RequiredAttribute")
            {
                attribute.ErrorMessage = "El campo {0} es obligatorio";
            }

            return baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
