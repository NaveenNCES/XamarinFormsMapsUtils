using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using Com.Google.Maps.Android.Data.Geojson;
using MapsXamarinForms.CustomRenderer;
using MapsXamarinForms.Droid.CustomRenderer;
using MapsXamarinForms.Models;
using Org.Json;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomGeoJsonRenderer), typeof(CustomGeoJsonMapRendererAndroid))]
namespace MapsXamarinForms.Droid.CustomRenderer
{
    [Obsolete]
    public class CustomGeoJsonMapRendererAndroid : MapRenderer, GeoJsonLayer.IGeoJsonOnFeatureClickListener
    {
        protected GoogleMap googleMap { get; private set; }
        protected MapFragment mapFragment { get; private set; }

        public CustomGeoJsonMapRendererAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if(e.PropertyName == "GeoJsonData")
            {
                var geoJsonData = (CustomGeoJsonRenderer)sender;
                string serializedData = JsonSerializer.Serialize<GeoJson>(geoJsonData.GeoJsonData);
                var jsonObjectGeoJson = new JSONObject(serializedData);
                GeoJsonLayer layer = new GeoJsonLayer(googleMap, jsonObjectGeoJson);
                AddGeoJsonLayerToMap(layer);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
            try
            {
                MainActivity.Instance.SetContentView(LayoutId());
                InitElements();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"			ERROR: ", ex.Message);
            }
        }

        private void InitElements()
        {
            mapFragment = MainActivity.Instance.FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map);
            mapFragment.GetMapAsync(this);
        }

        private int LayoutId()
        {
            return Resource.Layout.GeoJsonLayout;
        }

        protected override void OnMapReady(GoogleMap googleMap)
        {
            base.OnMapReady(googleMap);

            if (googleMap == null)
                return;

            this.googleMap = googleMap;
        }

        private void AddGeoJsonLayerToMap(GeoJsonLayer layer)
        {
            AddColorsToMarkers(layer);
            layer.AddLayerToMap();
            googleMap.MoveCamera(CameraUpdateFactory.NewLatLng(new LatLng(31.4118, -103.5355)));
            // Demonstrate receiving features via GeoJsonLayer clicks.
            layer.SetOnFeatureClickListener(this);
        }

        private void AddColorsToMarkers(GeoJsonLayer layer)
        {
            // Iterate over all the features stored in the layer
            foreach (Com.Google.Maps.Android.Data.Geojson.GeoJsonFeature feature in layer.Features.ToEnumerable())
            {
                // Check if the magnitude property exists
                if (feature.GetProperty("mag") != null && feature.HasProperty("place"))
                {
                    double magnitude = Double.Parse(feature.GetProperty("mag"));

                    // Get the icon for the feature
                    BitmapDescriptor pointIcon = BitmapDescriptorFactory.DefaultMarker(MagnitudeToColor(magnitude));

                    // Create a new point style
                    GeoJsonPointStyle pointStyle = new GeoJsonPointStyle();

                    // Set options for the point style
                    pointStyle.Icon = pointIcon;
                    pointStyle.Title = "Magnitude of " + magnitude;
                    pointStyle.Snippet = "Earthquake occured " + feature.GetProperty("place");

                    // Assign the point style to the feature
                    feature.PointStyle = pointStyle;
                }
            }
        }

        private static float MagnitudeToColor(double magnitude)
        {
            if (magnitude < 1.0)
            {
                return BitmapDescriptorFactory.HueCyan;
            }
            else if (magnitude < 2.5)
            {
                return BitmapDescriptorFactory.HueGreen;
            }
            else if (magnitude < 4.5)
            {
                return BitmapDescriptorFactory.HueYellow;
            }
            else
            {
                return BitmapDescriptorFactory.HueRed;
            }
        }

        public void OnFeatureClick(Com.Google.Maps.Android.Data.Feature p0)
        {
            Toast.MakeText(Context, "Feature clicked: " + p0.GetProperty("title"), ToastLength.Short).Show();
        }
    }
}