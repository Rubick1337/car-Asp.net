using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Car_oop.Models.Exception_custom
{
    public static class FluentValidationModelStateExtensions
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        } 
    } 
}
