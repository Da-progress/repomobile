using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoDo.MAUI.ViewModels;

namespace LoDo.MAUI.Views.Pages;

public partial class SponsorshipPage : ContentPage
{
    public SponsorshipPage(SponsorshipPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}