
using LoDo.MAUI.Services.Interfaces;
#if ANDROID
using Android.Util;
using LoDo.MAUI.NativeServices;
using Mopups.Services;
#endif

namespace LoDo.MAUI.Views.Popups;

public partial class AuthorizePopup
{
    private bool flag = false;
    private int id;
    private ILoDoApi _api;
    TaskCompletionSource<bool> _taskCompletionSource;
    public Task<bool> PopupDismissedTask => _taskCompletionSource.Task;
    public AuthorizePopup(ILoDoApi api, int id)
    {
        InitializeComponent();
        _api = api;
        this.id = id;
        _taskCompletionSource = new TaskCompletionSource<bool>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _taskCompletionSource.SetResult(flag);
    }
}