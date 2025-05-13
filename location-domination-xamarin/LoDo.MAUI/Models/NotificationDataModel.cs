using CommunityToolkit.Mvvm.ComponentModel;

namespace LoDo.MAUI.Models;

public partial class NotificationDataModel : ObservableObject
{
    [ObservableProperty] private Guid _notificationId;
    [ObservableProperty] private bool _isOpened = false;
    [ObservableProperty] private string _header = string.Empty;
    [ObservableProperty] private string _headerText = string.Empty;
    [ObservableProperty] private string _bodyHeader = string.Empty;
    [ObservableProperty] private string _bodyText = string.Empty;
    
}