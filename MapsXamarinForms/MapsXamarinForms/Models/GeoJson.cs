﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MapsXamarinForms.Models
{
    public class GeoJsonFeature
    {
        public string type { get; set; }
        public GeoJsonProperties properties { get; set; }
        public GeoJsonGeometry geometry { get; set; }
        public string id { get; set; }
    }

    public class GeoJsonGeometry
    {
        public string type { get; set; }
        public List<object> coordinates { get; set; }
    }

    public class GeoJsonMetadata
    {
        public long generated { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string api { get; set; }
        public int count { get; set; }
    }

    public class GeoJsonProperties
    {
        public double mag { get; set; }
        public string place { get; set; }
        public object time { get; set; }
        public object updated { get; set; }
        public int tz { get; set; }
        public string url { get; set; }
        public string detail { get; set; }
        public int? felt { get; set; }
        public double? cdi { get; set; }
        public double? mmi { get; set; }
        public string alert { get; set; }
        public string status { get; set; }
        public int tsunami { get; set; }
        public int sig { get; set; }
        public string net { get; set; }
        public string code { get; set; }
        public string ids { get; set; }
        public string sources { get; set; }
        public string types { get; set; }
        public int? nst { get; set; }
        public double? dmin { get; set; }
        public double rms { get; set; }
        public double? gap { get; set; }
        public string magType { get; set; }
        public string type { get; set; }
        public string title { get; set; }
    }

    public class GeoJson
    {
        public string type { get; set; }
        public GeoJsonMetadata metadata { get; set; }
        public List<GeoJsonFeature> features { get; set; }
        public List<double> bbox { get; set; }
    }


}
