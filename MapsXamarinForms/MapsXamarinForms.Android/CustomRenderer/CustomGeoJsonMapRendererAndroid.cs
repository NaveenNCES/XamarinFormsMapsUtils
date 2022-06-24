using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Google.Maps.Android.Clustering;
using Com.Google.Maps.Android.Data;
using Com.Google.Maps.Android.Data.Geojson;
using MapsXamarinForms.CustomRenderer;
using MapsXamarinForms.Droid.CustomRenderer;
using Org.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
            try
            {
                MainActivity.Instance.SetContentView(LayoutId());
                InitElements();
                RetrieveFileFromUrl();
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

        private void RetrieveFileFromUrl()
        {
            DownloadGeoJsonFile(Context.GetString(Resource.String.geojson_url));
        }


        private void RetrieveFileFromResource()
        {
            try
            {
                GeoJsonLayer layer = new GeoJsonLayer(googleMap, Resource.Raw.earthquakes_with_usa, Context);
                AddGeoJsonLayerToMap(layer);
            }
            catch (Exception)
            {
                Console.WriteLine("GeoJSON file could not be read");
            }
        }

        private async void DownloadGeoJsonFile(string url)
        {
            await Task.Factory.StartNew(() =>
            {
                using (var Client = new HttpClient())
                {
                    var response = Client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var layer = new GeoJsonLayer(googleMap, new JSONObject(response.Content.ReadAsStringAsync().Result));
                        MainActivity.Instance.RunOnUiThread(() =>
                        {
                            AddGeoJsonLayerToMap(layer);
                        });
                    }
                }
            }).ConfigureAwait(false);
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
            foreach (GeoJsonFeature feature in layer.Features.ToEnumerable())
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

        public void OnFeatureClick(Feature p0)
        {
            Toast.MakeText(Context, "Feature clicked: " + p0.GetProperty("title"), ToastLength.Short).Show();
        }
    }
}