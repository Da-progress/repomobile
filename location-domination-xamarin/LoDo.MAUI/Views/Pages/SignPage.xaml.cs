using LoDo.MAUI.ViewModels;

namespace LoDo.MAUI.Views.Pages;

public partial class SignPage : ContentPage
{
	public SignPage(SingPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private void PassButtonPressed(object sender, EventArgs e)
	{
		PassInput.IsPassword = false;
	}

	private void PassButtonReleased(object sender, EventArgs e)
	{
		PassInput.IsPassword = true;
	}

	private void PassRepButtonPressed(object sender, EventArgs e)
	{
		ConfInput.IsPassword = false;
	}
	
	private void PassRepButtonReleased(object sender, EventArgs e)
	{
		ConfInput.IsPassword = true;
	}
}