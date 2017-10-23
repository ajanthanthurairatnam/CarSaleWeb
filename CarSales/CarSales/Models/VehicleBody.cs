using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSales.Models
{
    public class VehicleBody
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("BodyDescription")]
        public string BodyDescription { get; set; }

        [JsonProperty("ImageURL")]
        public string ImageURL { get; set; }

    }
}