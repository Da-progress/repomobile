using LoDo.MAUI.ViewModels.PopupViewModels;
using Microsoft.Extensions.DependencyInjection;
using ServiceProvider = LoDo.MAUI.Services.ServiceProvider;

namespace LoDo.MAUI.Views.Popups;

public partial class GamesFilterPopup 
{
	public GamesFilterPopup()
	{
		InitializeComponent();
        BindingContext = ServiceProvider.GetService<GamesFilterPopupViewModel>();
    }
}