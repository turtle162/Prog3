using System;

namespace WpfApp2.Models
{
    public interface ICar
    {
        string BodyStyle { get; set; }
        DateTime DateProduction { get; set; }
        string EngineType { get; set; }
        string FuelType { get; set; }
        string Id { get; set; }
        
        int OdoMeter { get; set; }
        string Model { get; set; }
        string Brand { get; set; }
    }
}