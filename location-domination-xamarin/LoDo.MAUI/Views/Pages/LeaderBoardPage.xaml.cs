using LoDo.MAUI.ViewModels;

namespace LoDo.MAUI.Views.Pages;

public partial class LeaderBoardPage : ContentPage
{
	public LeaderBoardPage(LeaderBoardPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}