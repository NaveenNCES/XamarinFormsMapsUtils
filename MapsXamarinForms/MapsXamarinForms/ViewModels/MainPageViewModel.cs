using MapsXamarinForms.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapsXamarinForms.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            GeoJsonCommand = new DelegateCommand(GeoJsonCommandHandler);
            ClusterCommand = new DelegateCommand(ClusterCommandHandler);
        }        

        public DelegateCommand GeoJsonCommand { get; }
        public DelegateCommand ClusterCommand { get; }

        private async void GeoJsonCommandHandler()
        {
            await _navigationService.NavigateAsync(nameof(GeoJsonMap));
        }

        private async void ClusterCommandHandler()
        {
            await _navigationService.NavigateAsync(nameof(ClusterMap));
        }
    }
}
