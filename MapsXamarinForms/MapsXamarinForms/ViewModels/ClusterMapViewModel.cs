using MapsXamarinForms.CustomRenderer;
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
    public class ClusterMapViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMapService _mapService;
        private List<Cluster> _clusterResponseData;

        public ClusterMapViewModel(INavigationService navigationService, IMapService mapService) : base(navigationService)
        {
            _navigationService = navigationService;
            _mapService = mapService;
        }

        public List<Cluster> ClusterResponseData
        {
            get { return _clusterResponseData; }
            set { SetProperty(ref _clusterResponseData, value); }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            GetClusterData();
        }

        private async void GetClusterData()
        {
            ClusterResponseData = await _mapService.GetClustersAsync();
        }
    }
}
