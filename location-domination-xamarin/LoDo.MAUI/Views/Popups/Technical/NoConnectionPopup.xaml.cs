using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.Views.Popups.Technical;

public partial class NoConnectionPopup 
{
    public NoConnectionPopup()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
// #if ANDROID
//         BgFrame.AndroidBlurOverlayColor = new Color(21, 60, 100);
//         BgFrame.AndroidBlurRadius = 3;
// #endif
        // await Task.Delay(300);
        // PopupBackground.FadeTo(1, 500, Easing.Linear);
    }
}