using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.ViewModels
{
    public partial class StatsPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> _stats;

        public StatsPageViewModel()
        {
            Stats = new ObservableCollection<string>() { String.Empty, String.Empty, String.Empty, string.Empty };
        }
    }
}
