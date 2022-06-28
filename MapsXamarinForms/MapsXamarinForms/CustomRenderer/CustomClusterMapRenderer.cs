using MapsXamarinForms.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapsXamarinForms.CustomRenderer
{
    public class CustomClusterMapRenderer : Map
    {
        public static readonly BindableProperty ClusterDataProperty = BindableProperty.Create(nameof(ClusterData), typeof(List<Cluster>), typeof(CustomClusterMapRenderer),new List<Cluster>());
                
        public List<Cluster> ClusterData
        {
            get { return (List<Cluster>)GetValue(ClusterDataProperty); }
            private set { SetValue(ClusterDataProperty, value); }
        }
    }
}
