using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mopups.Services;

namespace LoDo.MAUI.Views.Popups;

public partial class UnregisteredPopup 
{
    public UnregisteredPopup()
    {
        InitializeComponent();
    }

    private async void SignInTapped(object? sender, EventArgs e)
    {
        Vibration.Vibrate(20);
        await MopupService.Instance.PopAsync();
        await Shell.Current.GoToAsync("//SingPage");
    }

    private async void LoginTapped(object? sender, EventArgs e)
    {
        Vibration.Vibrate(20);
        await MopupService.Instance.PopAsync();
        await Shell.Current.GoToAsync("//LoginPage");
    }
}