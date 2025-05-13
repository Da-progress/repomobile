using LoDo.MAUI.ViewModels;
using LoDo.MAUI.Views.Popups.Technical;
using Mopups.Services;

namespace LoDo.MAUI.Views.Pages;

public partial class AboutPage : ContentPage
{
	public AboutPage(AboutPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
	{
		
	}
}