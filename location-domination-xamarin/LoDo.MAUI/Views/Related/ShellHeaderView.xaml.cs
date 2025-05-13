using LoDo.MAUI.Models.DTOs;
using LoDo.MAUI.Services.Implementations;

namespace LoDo.MAUI.Views.Related;

public partial class ShellHeaderView : ContentView
{
	private bool _firstLaunch = true;
	public ShellHeaderView()
	{
		InitializeComponent();
	}
	

	protected override void OnBindingContextChanged()
	{
		base.OnBindingContextChanged();
		SetAvatar();
	}

	public async void SetAvatar()
	{
		try
		{
			var cachedFilePath = Preferences.Get("avatar", string.Empty);

			if (!File.Exists(cachedFilePath))
				return;

			var hasChanged = Preferences.Get("avatarChanged", true);
			if (_firstLaunch)
			{
				hasChanged = true;
				_firstLaunch = false;
			}

			if (!hasChanged)
				return;
			var imageSource = ImageSource.FromFile(cachedFilePath);
			AvatarImage.Source = imageSource;
			Preferences.Set("avatarChanged", false);
			var data = new CacheService().GetObject<UserRegisteredDTO>("userData");
			GreetingsLabel.Text = $"Welcome, {data.RegisteredPlayer.Username}";
			DateLabel.Text = $"Registered on {data.RegisteredPlayer.RegisterDateTime.Substring(0, 10)}";
		}
		catch (Exception ex)
		{
			
		}
	}
}