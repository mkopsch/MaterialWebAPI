namespace MaterialWebAPI.Domain.Entities
{
    public class MaterialFunction
    {
        public double MinTemperature { get;  set; }
        public double MaxTemperature { get;  set; }
        

        public MaterialFunction(double minTemperature, double maxTemperature)
        {
            MinTemperature = minTemperature;

            MaxTemperature = maxTemperature; 
        }
    }
}