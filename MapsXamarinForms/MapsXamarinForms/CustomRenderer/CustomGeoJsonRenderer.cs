using MapsXamarinForms.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapsXamarinForms.CustomRenderer
{
    public class CustomGeoJsonRenderer : Map
    {
        public static readonly BindableProperty GeoJsonDataProperty = BindableProperty.Create(nameof(GeoJsonData), typeof(GeoJson), typeof(CustomGeoJsonRenderer), new GeoJson());

        public GeoJson GeoJsonData
        {
            get { return (GeoJson)GetValue(GeoJsonDataProperty); }
            private set { SetValue(GeoJsonDataProperty, value); }
        }
    }
}
