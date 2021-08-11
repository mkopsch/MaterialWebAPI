using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MaterialWebAPI.Application.Models
{
    public class IsTypeOfPhaseAttribute : ValidationAttribute
    {
        private string[] TypesOfPhases = {"solid", "liquid"};

        public string GetErrorMessage() =>  $"Type of Phase is not valid";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var materialmodel = (MaterialModel)validationContext.ObjectInstance;

            var typeofPhase = (string)value;

            if (!IsTypeOfPhase(materialmodel.TypeOfPhase))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
        public bool IsTypeOfPhase(string typeOfPhase)
        {
            if(TypesOfPhases.Any(typeOfPhase.Contains))
            return true;
            
            return false;
        }
    }
}