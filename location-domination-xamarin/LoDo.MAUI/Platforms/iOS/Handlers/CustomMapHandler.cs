﻿using CoreLocation;
using LoDo.MAUI.Views.Related.Controls.Map;
using MapKit;
using Microsoft.Maui.Maps.Handlers;
using Microsoft.Maui.Maps.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace LoDo.MAUI.Platforms.iOS.Handlers.Map
{
   public partial class CustomMapHandler : MapHandler
    {
        private readonly Dictionary<string, UIImage> _iconMap = [];

        public static new IPropertyMapper<ImageMap, CustomMapHandler> Mapper = new PropertyMapper<ImageMap, CustomMapHandler>(MapHandler.Mapper)
        {
            [nameof(ImageMap.CustomPins)] = MapPins
        };

        public Dictionary<IMKAnnotation, ImagePin> MarkerMap { get; } = [];

        public CustomMapHandler()
            : base(Mapper)
        {
        }

        protected override void ConnectHandler(MauiMKMapView platformView)
        {
            base.ConnectHandler(platformView);

            platformView.DidSelectAnnotationView += CustomMapHandler_DidSelectAnnotationView;
            platformView.GetViewForAnnotation += GetViewForAnnotation;
        }

        protected override void DisconnectHandler(MauiMKMapView platformView)
        {
            base.DisconnectHandler(platformView);

            platformView.DidSelectAnnotationView -= CustomMapHandler_DidSelectAnnotationView;
            platformView.GetViewForAnnotation -= GetViewForAnnotation;
        }

        private void CustomMapHandler_DidSelectAnnotationView(object sender, MKAnnotationViewEventArgs e)
        {
            if (MarkerMap.TryGetValue(e.View.Annotation, out ImagePin value))
            {
                value.ClickedCommand?.Execute(null);
                PlatformView.DeselectAnnotation(e.View.Annotation, false);
            }
        }

        private static new void MapPins(IMapHandler handler, Microsoft.Maui.Maps.IMap map)
        {
            if (handler is CustomMapHandler mapHandler && handler.VirtualView is ImagePin mapEx)
            {
                handler.PlatformView.RemoveAnnotations(mapHandler.MarkerMap.Select(x => x.Key).ToArray());

                mapHandler.MarkerMap.Clear();

                mapHandler.AddPins();
            }
        }

        private void AddPins()
        {
            if (VirtualView is ImageMap mapEx)
            {
                foreach (var pin in mapEx.CustomPins)
                {
                    var marker = new MKPointAnnotation(new CLLocationCoordinate2D(pin.Position.Latitude, pin.Position.Longitude));

                    PlatformView.AddAnnotation(marker);

                    MarkerMap.Add(marker, pin);
                }
            }
        }

        private MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            if (annotation == null || annotation is MKUserLocation)
            {
                return null;
            }

            var customPin = GetCustomPin(annotation);

            if (customPin == null)
            {
                return null;
            }

            return mapView.DequeueReusableAnnotation(customPin.Id) ?? new MKAnnotationView
            {
                Image = GetIcon(customPin.Icon),
                CanShowCallout = false
            };
        }

        private ImagePin GetCustomPin(IMKAnnotation mkPointAnnotation)
        {
            if (MarkerMap.TryGetValue(mkPointAnnotation, out ImagePin value))
            {
                return value;
            }

            return null;
        }

        private UIImage GetIcon(string icon)
        {
            if (_iconMap.TryGetValue(icon, out UIImage? value))
            {
                return value;
            }

            var image = UIImage.FromBundle(icon);

            _iconMap[icon] = image;

            return image;
        }
    }
}
