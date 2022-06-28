using AutoMapper;
using Flurl.Http;
using Flurl.Http.Configuration;
using MapsXamarinForms.Services;
using MapsXamarinForms.Services.Interface;
using MapsXamarinForms.Utils;
using MapsXamarinForms.ViewModels;
using MapsXamarinForms.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace MapsXamarinForms
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");

            FlurlHttp.Configure(settings => { settings.HttpClientFactory = new CustomHttpClientFactory(); });
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
            containerRegistry.RegisterSingleton<IMapService, MapService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<GeoJsonMap, GeoJsonMapViewModel>();
            containerRegistry.RegisterForNavigation<ClusterMap, ClusterMapViewModel>();

            containerRegistry.RegisterInstance(new MapperConfiguration(cfg => cfg.AddMaps(typeof(App).Assembly)).CreateMapper());
        }
    }
}
