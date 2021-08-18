using System.ComponentModel.DataAnnotations;
using MaterialWebAPI.Domain.Entities;

namespace MaterialWebAPI.Application.Models
{
    public class MaterialModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsVisible { get; set; }

        [Required]
        [IsTypeOfPhaseAttribute]
        public string TypeOfPhase { get; set; }

        [Required]
        [MinTemperatureIsNotHigherThanMaxTemperatureAttribut]
        public MaterialFunction MaterialFunction { get; set; }
    }
}