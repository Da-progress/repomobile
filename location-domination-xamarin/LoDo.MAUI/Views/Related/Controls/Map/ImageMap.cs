using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.Views.Related.Controls.Map
{
    public class ImageMap : Microsoft.Maui.Controls.Maps.Map
    {
        public static readonly BindableProperty CustomPinsProperty = BindableProperty.Create(
            nameof(CustomPins), 
            typeof(ObservableCollection<ImagePin>), 
            typeof(ImagePin), null);

        public ObservableCollection<ImagePin> CustomPins
        {
            get { return (ObservableCollection<ImagePin>)GetValue(CustomPinsProperty); }
            set { SetValue(CustomPinsProperty, value); }
        }

        public ImageMap()
        {
            CustomPins = new ObservableCollection<ImagePin>();
        }
    }
}
