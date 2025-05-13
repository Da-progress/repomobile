using LoDo.MAUI.ViewModels;

namespace LoDo.MAUI.Views.Pages;

public partial class MyGamesPage : ContentPage
{
	public MyGamesPage(MyGamesPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}