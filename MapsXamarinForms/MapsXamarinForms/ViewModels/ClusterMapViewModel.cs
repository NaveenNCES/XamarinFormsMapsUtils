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

        public ClusterMapViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
