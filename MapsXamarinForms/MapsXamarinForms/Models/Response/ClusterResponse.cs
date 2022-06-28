using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapsXamarinForms.Models
{
    public class ClusterResponse
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("snippet", NullValueHandling = NullValueHandling.Ignore)]
        public string Snippet { get; set; }
    }
}
