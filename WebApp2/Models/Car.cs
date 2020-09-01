using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp2.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public Model Model { get; set; }
        public DateTime DateProduction { get; set; }
        public string FuelType { get; set; }
        public string BodyStyle { get; set; }
        public int OdoMeter { get; set; }
        public string EngineType { get; set; }


    }
}