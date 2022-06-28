using AutoMapper;
using Flurl.Http;
using Flurl.Http.Configuration;
using MapsXamarinForms.Models;
using MapsXamarinForms.Services.Interface;
using MapsXamarinForms.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MapsXamarinForms.Services
{
    public class MapService : IMapService
    {
        private readonly IFlurlClient _flurlClient;
        private IMapper _mapper;

        public MapService(IFlurlClientFactory flurlClientFactory,IMapper mapper)
        {
            _mapper = mapper;
            _flurlClient = flurlClientFactory.Get("https://run.mocky.io/v3/");
        }

        public async Task<List<Cluster>> GetClustersAsync()
        {
            return _mapper.Map<List<ClusterResponse>, List<Cluster>>(await _flurlClient.Request("65e1920c-552d-4abe-8e85-5b7b5281bbaa").GetJsonAsync<List<ClusterResponse>>());
        }

        public async Task<GeoJson> GetGeoJsonAsync()
        {
            return _mapper.Map<GeoJsonResponse,GeoJson>(await _flurlClient.Request("2e145905-140c-4f96-905a-7684793b5b8b").GetJsonAsync<GeoJsonResponse>());
        }       
    }
}
