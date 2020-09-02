using System;

namespace WpfApp2.Models
{
    public interface IModelAdd
    {
        string Brand_ { get; set; }
        DateTime FirstDateProduction { get; set; }
        string Name { get; set; }
    }
}