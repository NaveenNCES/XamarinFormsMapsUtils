using AutoMapper;
using MapsXamarinForms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapsXamarinForms.Profiles
{
    public class MapMapperProfile : Profile
    {
        public MapMapperProfile()
        {
            CreateMap<ClusterResponse, Cluster>();
            CreateMap<GeoJsonResponse, GeoJson>();
            CreateMap<Properties, GeoJsonProperties>();
            CreateMap<Feature, GeoJsonFeature>();
            CreateMap<Metadata, GeoJsonMetadata>();
            CreateMap<Geometry, GeoJsonGeometry>();
        }
    }
}
