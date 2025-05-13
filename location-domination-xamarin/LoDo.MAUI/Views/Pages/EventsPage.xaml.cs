using LoDo.MAUI.ViewModels;
using UraniumUI.Pages;

namespace LoDo.MAUI.Views.Pages;

public partial class EventsPage : ContentPage
{
	public EventsPage(EventsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}