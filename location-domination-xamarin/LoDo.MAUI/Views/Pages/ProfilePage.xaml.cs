using LoDo.MAUI.ViewModels;

namespace LoDo.MAUI.Views.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfilePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		SetAvatar();
		await Task.Delay(2000);
		var test = FirstRow.Height;
	}

	private async void SetAvatar()
	{
		var cachedFilePath = Preferences.Get("avatar", string.Empty);
		
		if (!File.Exists(cachedFilePath))
			return;

		var imageSource = ImageSource.FromFile(cachedFilePath);
		
		AvatarImage.Source = imageSource;
	}
}