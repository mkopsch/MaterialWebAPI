namespace MaterialWebAPI.Domain.Entities
{
    public class Material
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsVisible { get; set; }
    
        public string TypeOfPhase {get; set;}

        public MaterialFunction MaterialFunction {get; set;}

        public Material(string id, string name, bool isVisible, string typeOfPhase, MaterialFunction materialFunction)
        {
            Id = id ?? null;
            Name = name;
            IsVisible = isVisible;
            TypeOfPhase = typeOfPhase;
            MaterialFunction = materialFunction;
        }

        public Material()
        {
            
        }

    }
}