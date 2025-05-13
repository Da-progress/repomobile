using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoDo.MAUI.ViewModels;

namespace LoDo.MAUI.Views.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    
    private void PassButtonPressed(object sender, EventArgs e)
    {
        PassInput.IsPassword = false;
    }

    private void PassButtonReleased(object sender, EventArgs e)
    {
        PassInput.IsPassword = true;
    }

}