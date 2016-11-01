using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class Engine : IEngine
    {
        public string Name { get; set; }
        public string Cylinders { get; set; }
        public float Displacement { get; set; }
        public string FuelInduction { get; set; }
        public string FuelQuality { get; set; }
        public string FuelType { get; set; }
        public string MaxHp { get; set; }
        public string MaxHpAt { get; set; }
    }
}