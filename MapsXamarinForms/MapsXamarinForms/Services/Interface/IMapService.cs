using MapsXamarinForms.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MapsXamarinForms.Services.Interface
{
    public interface IMapService
    {
        Task<List<Cluster>> GetClustersAsync();

        Task<GeoJson> GetGeoJsonAsync();
    }
}
