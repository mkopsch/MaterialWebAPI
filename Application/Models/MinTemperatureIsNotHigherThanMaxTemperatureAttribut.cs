using System.ComponentModel.DataAnnotations;
using MaterialWebAPI.Domain.Entities;

namespace MaterialWebAPI.Application.Models
{
    public class MinTemperatureIsNotHigherThanMaxTemperatureAttribut : ValidationAttribute
    {
        public string GetErrorMessage() => $"MinTemperature Is Equal Or Higher Than MaxTemperature";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var materialmodel = (MaterialModel)validationContext.ObjectInstance;

            var materialFunction = (MaterialFunction)value;

            if (MinTemperatureIsHigherThanMaxTemperature(materialFunction))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public bool MinTemperatureIsHigherThanMaxTemperature(MaterialFunction materialFunction)
        {
            return materialFunction.MinTemperature >= materialFunction.MaxTemperature;
        }
    }
}