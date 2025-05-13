using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using LoDo.MAUI.Models;

namespace LoDo.MAUI.ViewModels.PopupViewModels;

public partial class NotificationBoardPopupViewModel : ModelBase
{
    [ObservableProperty] private bool _isBusy = false;
    [ObservableProperty] private ObservableCollection<NotificationDataModel> _notificationList;

    public ICommand GetNotificationDetailsCommand => new Command(OnGetNotificationDetailsCommand);
    public ICommand OpenNotificationInfoCommand => new Command<object>(OnOpenNotificationInfoCommand);

    public NotificationBoardPopupViewModel()
    {
        LoadList();
    }

    private async void LoadList()
    {
        IsBusy = true;
        await Task.Delay(3000);
        NotificationList = new ObservableCollection<NotificationDataModel>();
        NotificationList.Add(new NotificationDataModel()
        {
            Header = "Game requested",
            HeaderText = "Ready to rumble? Alex suggests \na showdown. Do you accept \nthe challenge?",
            BodyHeader = "Example notification",
            BodyText = "Just an example notification",
            IsOpened = false,
        });
        NotificationList.Add(new NotificationDataModel()
        {
            Header = "Game requested",
            HeaderText = "Ready to rumble? Alex suggests \na showdown. Do you accept \nthe challenge?",
            BodyHeader = "Example notification",
            BodyText = "Just an example notification",
            IsOpened = false,
        });
        NotificationList.Add(new NotificationDataModel()
        {
            Header = "Game requested",
            HeaderText = "Ready to rumble? Alex suggests \na showdown. Do you accept \nthe challenge?",
            BodyHeader = "Example notification",
            BodyText = "Just an example notification",
            IsOpened = false,
        });
        NotificationList.Add(new NotificationDataModel()
        {
            Header = "Game requested",
            HeaderText = "Ready to rumble? Alex suggests \na showdown. Do you accept \nthe challenge?",
            BodyHeader = "Example notification",
            BodyText = "Just an example notification",
            IsOpened = false,
        });
        NotificationList.Add(new NotificationDataModel()
        {
            Header = "Game requested",
            HeaderText = "Ready to rumble? Alex suggests \na showdown. Do you accept \nthe challenge?",
            BodyHeader = "Example notification",
            BodyText = "Just an example notification",
            IsOpened = false,
        });
        IsBusy = false;
    }
    
    private async void OnGetNotificationDetailsCommand()
    {
        var check = NotificationList;
        check.First().IsOpened = true;
    }

    private void OnOpenNotificationInfoCommand(object obj)
    {
        var n = obj as NotificationDataModel;
        n.IsOpened = !n.IsOpened;
    }
}