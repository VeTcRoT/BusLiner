using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BusLiner.MVC.Extensions
{
    public static class ExtensionsClass
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        public static void AddToModelStateWithObjectName(this ValidationResult result, ModelStateDictionary modelState, string obj)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(obj + "." + error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
