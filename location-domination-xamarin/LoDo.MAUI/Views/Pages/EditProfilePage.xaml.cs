using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoDo.MAUI.ViewModels;

namespace LoDo.MAUI.Views.Pages;

public partial class EditProfilePage : ContentPage
{
    public EditProfilePage(EditProfilePageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var vm = BindingContext as EditProfilePageViewModel;
        vm.AvatarImage = AvatarImage;
    }
}