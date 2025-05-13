using LoDo.MAUI.Views.Pages;
using LoDo.MAUI.Services;
using ServiceProvider = LoDo.MAUI.Services.ServiceProvider;
using LoDo.MAUI.ViewModels;

namespace LoDo.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var page = ServiceProvider.GetService<LeaderBoardPage>();
            if (true)
                MainPage = new AppShell();
            else
                MainPage = new UnloggedShell();
        }
        
    }
}
