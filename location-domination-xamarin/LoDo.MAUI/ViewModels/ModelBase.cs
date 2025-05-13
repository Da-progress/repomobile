using CommunityToolkit.Mvvm.ComponentModel;
using LoDo.MAUI.Services.Interfaces;
using LoDo.MAUI.Views.Popups;
using Mopups.Services;

namespace LoDo.MAUI.ViewModels;

public class ModelBase : ObservableObject
{
    public virtual ISettings Settings { get; set; }

    public ModelBase()
    {
        Settings = IPlatformApplication.Current.Services.GetService<ISettings>();
    }

    public virtual void Vibrate()
    {
        Settings.ShouldVibrate = true;
        if(Settings.ShouldVibrate)
            Vibration.Vibrate(80);
    }

    public virtual async Task<bool> CheckIfLogged()
    {
        return false;
        if (!Preferences.ContainsKey("isLoggedIn"))
        {
            await MopupService.Instance.PushAsync(new UnregisteredPopup());
            return true;
        }
        else
        {
            return false;
        }
    }
}