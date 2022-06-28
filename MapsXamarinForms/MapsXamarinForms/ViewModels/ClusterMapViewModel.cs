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
        private List<Cluster> _cluster;

        public ClusterMapViewModel(INavigationService navigationService, IMapService mapService) : base(navigationService)
        {
            _navigationService = navigationService;
            _mapService = mapService;
        }

        public List<Cluster> ClusterDatas
        {
            get { return _cluster; }
            set { SetProperty(ref _cluster, value); }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            GetClusterData();
        }

        private async void GetClusterData()
        {
            ClusterDatas = await _mapService.GetClustersAsync();
        }
    }
}
