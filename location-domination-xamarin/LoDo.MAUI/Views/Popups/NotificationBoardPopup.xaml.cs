using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoDo.MAUI.ViewModels.PopupViewModels;

namespace LoDo.MAUI.Views.Popups;

public partial class NotificationBoardPopup
{
    public NotificationBoardPopup(NotificationBoardPopupViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}