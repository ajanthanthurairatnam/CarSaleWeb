using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSales.Models
{
    public class VehicleAdvertisement
    {
        [JsonProperty("Reference_ID")]
        public int ID { get; set; }

        [JsonProperty("Title")]
        public string VehicleAdvertisementNextRefNo { get; set; }

        [JsonProperty("Reference_No")]
        public string Reference_No { get; set; }

        [JsonProperty("Price")]
        public decimal? Price { get; set; }

        [JsonProperty("BodyType")]
        public int? BodyType { get; set; }

        [JsonProperty("EngineCapacity")]
        public int? EngineCapacity { get; set; }

        [JsonProperty("AudoMeter")]
        public decimal? AudoMeter { get; set; }

        [JsonProperty("Fuel")]
        public int? Fuel { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}