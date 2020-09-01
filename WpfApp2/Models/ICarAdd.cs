using System;

namespace WpfApp2.Models
{
    public interface ICarAdd
    {
        string BodyStyle { get; set; }
        DateTime DateProduction { get; set; }
        string EngineType { get; set; }
        string FuelType { get; set; }
        string Id { get; set; }

        string Model { get; set; }
        int OdoMeter { get; set; }
    }
}