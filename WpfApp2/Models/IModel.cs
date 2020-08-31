using System;

namespace WpfApp2.Models
{
    public interface IModel
    {
        int BrandId { get; set; }
        DateTime FirstDateProduction { get; set; }
        int id { get; set; }
        string Name { get; set; }
    }
}