using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSales.Models
{
    public class VehicleFuel
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("FuelType")]
        public string FuelType { get; set; }

    }
}