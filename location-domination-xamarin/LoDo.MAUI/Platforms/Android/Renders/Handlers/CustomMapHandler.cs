using System.Collections.Specialized;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using LoDo.MAUI.Views.Related.Controls.Map;
using Microsoft.Maui.Maps.Handlers;

namespace LoDo.MAUI.Renders.Handlers
{
    public partial class CustomMapHandler : MapHandler
    {
        private const int _iconSize = 40;
        private readonly Dictionary<string, BitmapDescriptor> _iconMap = [];

        public static new IPropertyMapper<ImageMap, CustomMapHandler> Mapper = new PropertyMapper<ImageMap, CustomMapHandler>(MapHandler.Mapper)
        {
            [nameof(ImageMap.CustomPins)] = MapPins
        };

        public Dictionary<string, (Marker Marker, ImagePin Pin)> MarkerMap { get; } = [];

        public CustomMapHandler()
            : base(Mapper)
        {
        }

        protected override void ConnectHandler(MapView platformView)
        {
            base.ConnectHandler(platformView);
            var mapReady = new MapCallbackHandler(this);
            PlatformView.GetMapAsync(mapReady);
            if (VirtualView is ImageMap mapEx && mapEx.CustomPins is INotifyCollectionChanged observable)
            {
                observable.CollectionChanged += CustomPins_CollectionChanged;
            }
        }

        protected override void DisconnectHandler(MapView platformView)
        {
            base.DisconnectHandler(platformView);
            
            if (VirtualView is ImageMap mapEx && mapEx.CustomPins is INotifyCollectionChanged observable)
            {
                observable.CollectionChanged -= CustomPins_CollectionChanged;
            }
        }

        private void CustomPins_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Обновляем пины при изменении коллекции
            MainThread.BeginInvokeOnMainThread(() => UpdateValue(nameof(ImageMap.CustomPins)));
        }

        private static new void MapPins(IMapHandler handler, Microsoft.Maui.Maps.IMap map)
        {
            if (handler.Map is null || handler.MauiContext is null)
            {
                return;
            }

            if (handler is CustomMapHandler mapHandler)
            {
                mapHandler.ClearMarkers();
                mapHandler.AddPins();
            }
        }

        private void ClearMarkers()
        {
            foreach (var marker in MarkerMap)
            {
                marker.Value.Marker.Remove();
            }
            MarkerMap.Clear();
        }

        private BitmapDescriptor GetIcon(string icon)
        {
            if (_iconMap.TryGetValue(icon, out BitmapDescriptor? value))
            {
                return value;
            }

            var drawableId = Context.Resources.GetIdentifier(icon, "drawable", Context.PackageName);
            if (drawableId == 0)
            {
                return BitmapDescriptorFactory.DefaultMarker(); // Вернём стандартный маркер, если ресурс не найден
            }

            var options = new BitmapFactory.Options
            {
                InPreferredConfig = Bitmap.Config.Argb8888, // Улучшенное качество
                InScaled = false  // Отключаем стандартное масштабирование
            };

            var bitmap = BitmapFactory.DecodeResource(Context.Resources, drawableId, options);

            // Учитываем плотность экрана
            float scaleFactor = Context.Resources.DisplayMetrics.Density;
            int scaledSize = (int)(_iconSize * scaleFactor); // Размер в пикселях, адаптированный под экран

            var scaledBitmap = Bitmap.CreateScaledBitmap(bitmap, scaledSize, scaledSize, true);
            bitmap.Recycle();

            var descriptor = BitmapDescriptorFactory.FromBitmap(scaledBitmap);

            _iconMap[icon] = descriptor;
            return descriptor;
        }

        private void AddPins()
        {
            if (VirtualView is ImageMap mapEx && mapEx.CustomPins != null)
            {
                foreach (var pin in mapEx.CustomPins)
                {
                    var markerOption = new MarkerOptions();
                    markerOption.SetTitle(string.Empty);
                    markerOption.SetIcon(GetIcon(pin.Icon));
                    markerOption.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
                    var marker = Map.AddMarker(markerOption);
                    MarkerMap.Add(marker.Id, (marker, pin));
                }
            }
        }

        public void MarkerClick(object sender, GoogleMap.MarkerClickEventArgs args)
        {
            if (MarkerMap.TryGetValue(args.Marker.Id, out (Marker Marker, ImagePin Pin) value))
            {
                value.Pin.ClickedCommand?.Execute(null);
            }
        }
    }

    public class MapCallbackHandler : Java.Lang.Object, IOnMapReadyCallback
    {
        private readonly CustomMapHandler mapHandler;

        public MapCallbackHandler(CustomMapHandler mapHandler)
        {
            this.mapHandler = mapHandler;
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mapHandler.UpdateValue(nameof(ImageMap.CustomPins));
            googleMap.UiSettings.ZoomControlsEnabled = false;
            googleMap.UiSettings.CompassEnabled = false;
            googleMap.UiSettings.MapToolbarEnabled = false;
            googleMap.UiSettings.MyLocationButtonEnabled = false;
            googleMap.MarkerClick += mapHandler.MarkerClick;
        }
    }
}
