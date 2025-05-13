using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoDo.MAUI.ViewModels.PopupViewModels;

namespace LoDo.MAUI.Views.Popups;

public partial class FeedbackPopup 
{
    public FeedbackPopup()
    {
        try
        {
            BindingContext = new FeedbackPopupViewModel();
            InitializeComponent();
        }
        catch (Exception ex)
        
        {
            Console.WriteLine(ex.Message);
        }
    }
}