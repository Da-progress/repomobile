using Microsoft.Maui.Controls.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;

namespace LoDo.MAUI.Views.Related.Controls.Map
{
    public class ImagePin
    {
        public string Id { get; set; }
        public Location Position { get; set; }
        public string Icon { get; set; }
        
        public string Name { get; set; }
        
        public ICommand ClickedCommand { get; set; }
        
        public string Address { get; set; }
        
        public ImagePin(Action<ImagePin> clicked = null)
        {
            ClickedCommand = new Command(() => clicked(this));
        }

        private static void PinClicked()
        {
            Toast.Make("Pin tapped").Show();
        }
    }
}
