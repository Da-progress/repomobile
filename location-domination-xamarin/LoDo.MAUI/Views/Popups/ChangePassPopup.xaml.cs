using LoDo.MAUI.ViewModels.PopupViewModels;

namespace LoDo.MAUI.Views.Popups;

public partial class ChangePassPopup 
{
	public ChangePassPopup()
	{
		InitializeComponent();
		BindingContext = new ChangePassPopupViewModel();
	}
}