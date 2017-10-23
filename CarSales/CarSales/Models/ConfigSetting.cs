using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSales.Models
{
    public class ConfigSetting
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("VehicleAdvertisementNextRefNo")]
        public int VehicleAdvertisementNextRefNo { get; set; }
    }
}