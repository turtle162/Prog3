using System;

namespace WpfApp2.Models
{
    public interface IBrandAdd
    {
        string Country { get; set; }
        DateTime DateCreated { get; set; }
        string Name { get; set; }
        string Owner { get; set; }
    }
}