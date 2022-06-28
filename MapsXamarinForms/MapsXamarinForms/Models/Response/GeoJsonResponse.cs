using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapsXamarinForms.Models
{
    public class Feature
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }

    public class Geometry
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<object> Coordinates { get; set; }
    }

    public class Metadata
    {
        [JsonProperty("generated")]
        public long Generated { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("api")]
        public string Api { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class Properties
    {
        [JsonProperty("mag")]
        public double? Mag { get; set; }

        [JsonProperty("place", NullValueHandling = NullValueHandling.Ignore)]
        public string Place { get; set; }

        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time { get; set; }

        [JsonProperty("updated", NullValueHandling = NullValueHandling.Ignore)]
        public long? Updated { get; set; }

        [JsonProperty("tz", NullValueHandling = NullValueHandling.Ignore)]
        public long? Tz { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Detail { get; set; }

        [JsonProperty("felt")]
        public long? Felt { get; set; }

        [JsonProperty("cdi")]
        public double? Cdi { get; set; }

        [JsonProperty("mmi")]
        public double? Mmi { get; set; }

        [JsonProperty("alert")]
        public string Alert { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("tsunami", NullValueHandling = NullValueHandling.Ignore)]
        public long? Tsunami { get; set; }

        [JsonProperty("sig", NullValueHandling = NullValueHandling.Ignore)]
        public long? Sig { get; set; }

        [JsonProperty("net", NullValueHandling = NullValueHandling.Ignore)]
        public string Net { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("ids", NullValueHandling = NullValueHandling.Ignore)]
        public string Ids { get; set; }

        [JsonProperty("sources", NullValueHandling = NullValueHandling.Ignore)]
        public string Sources { get; set; }

        [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
        public string Types { get; set; }

        [JsonProperty("nst")]
        public long? Nst { get; set; }

        [JsonProperty("dmin")]
        public double? Dmin { get; set; }

        [JsonProperty("rms", NullValueHandling = NullValueHandling.Ignore)]
        public double? Rms { get; set; }

        [JsonProperty("gap")]
        public double? Gap { get; set; }

        [JsonProperty("magType")]
        public string MagType { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class GeoJsonResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("features")]
        public List<Feature> Features { get; set; }

        [JsonProperty("bbox")]
        public List<double> Bbox { get; set; }
    }
}
