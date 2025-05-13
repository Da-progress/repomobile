using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.ViewModels
{
    public partial class AboutPageViewModel : ObservableObject
    {
        //private readonly LocaleService _localeService;

        private const string _supportEmail = "support@SvobodaZaleta.ch";

        public string SupportEmail => _supportEmail;

        
        public AboutPageViewModel()
        {
        }

        [RelayCommand]
        public void SetLanguage(string lang)
        {
        }
    }
}
