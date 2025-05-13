using LoDo.MAUI.ViewModels.PopupViewModels;
using ServiceProvider = LoDo.MAUI.Services.ServiceProvider;

namespace LoDo.MAUI.Views.Popups;

public partial class FastChangePassPopup 
{
	public FastChangePassPopup()
	{
		InitializeComponent();
        BindingContext = ServiceProvider.GetService<FastChangePassPopupViewModel>();
    }
}