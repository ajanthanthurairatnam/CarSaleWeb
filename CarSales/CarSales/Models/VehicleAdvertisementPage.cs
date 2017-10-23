using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSales.Models
{
    public class VehicleAdvertisementPage
    {
        [JsonProperty("PageIndex")]
        public int ID { get; set; }

        [JsonProperty("PageCount")]
        public string VehicleAdvertisementNextRefNo { get; set; }
       
        public virtual VehicleAdvertisement vehicleAdvertisement { get; set; }
    }
}