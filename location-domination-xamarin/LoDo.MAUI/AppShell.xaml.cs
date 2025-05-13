using LoDo.MAUI.Views.Pages;
using Toast = CommunityToolkit.Maui.Alerts.Toast;

namespace LoDo.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            this.PropertyChanging += (sender, args) => ShellHeaderView.SetAvatar();
            ShellHeaderView.SetAvatar();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute($"//ProfilePage/{nameof(MyGamesPage)}", typeof(MyGamesPage));
            Routing.RegisterRoute($"//ProfilePage/{nameof(StatsPage)}", typeof(StatsPage));
            Routing.RegisterRoute($"//ProfilePage/{nameof(EditProfilePage)}", typeof(EditProfilePage));
            Routing.RegisterRoute($"//MapPage/{nameof(LocationGamesPage)}", typeof(LocationGamesPage));
            Routing.RegisterRoute($"//MapPage/{nameof(AddLocationPage)}",typeof(AddLocationPage));
        }

        private async  void MenuItem_OnClicked(object? sender, EventArgs e)
        {
          await Toast.Make("Logged out!").Show();
        }
    }
}