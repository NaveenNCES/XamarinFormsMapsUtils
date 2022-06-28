using MapsXamarinForms.Models;
using MapsXamarinForms.Services.Interface;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapsXamarinForms.ViewModels
{
    public class GeoJsonMapViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMapService _mapService;
        private GeoJson _geoJsonResponseData;
        public GeoJsonMapViewModel(INavigationService navigationService, IMapService mapService) : base(navigationService)
        {
            _navigationService = navigationService;
            _mapService = mapService;
        }

        public GeoJson GeoJsonResponseData
        {
            get { return _geoJsonResponseData; }
            set { SetProperty(ref _geoJsonResponseData, value); }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            GetGeoJsonData();
        }

        private async void GetGeoJsonData()
        {
            GeoJsonResponseData = await _mapService.GetGeoJsonAsync();
        }
    }
}
