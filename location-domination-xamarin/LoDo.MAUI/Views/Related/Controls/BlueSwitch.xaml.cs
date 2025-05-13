using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using IeuanWalker.Maui.Switch;
using IeuanWalker.Maui.Switch.Events;
using IeuanWalker.Maui.Switch.Helpers;

namespace LoDo.MAUI.Views.Related.Controls;

public partial class BlueSwitch : ContentView
{
    public BlueSwitch()
    {
        InitializeComponent();
    }

    public event EventHandler<ToggledEventArgs>? Toggled = null;

    public static readonly BindableProperty IsToggledProperty =
        BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(BlueSwitch), false, BindingMode.TwoWay);

    public bool IsToggled
    {
        get => (bool)GetValue(IsToggledProperty);
        set => SetValue(IsToggledProperty, value);
    }

    public static readonly BindableProperty ToggledCommandProperty =
        BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(BlueSwitch));

    public ICommand ToggledCommand
    {
        get => (ICommand)GetValue(ToggledCommandProperty);
        set => SetValue(ToggledCommandProperty, value);
    }

    public CustomSwitch SwtichRef
    {
        get => this.CustomSwitch;
    }
    
    public void CustomSwitch_SwitchPanUpdate(CustomSwitch customSwitch, SwitchPanUpdatedEventArgs e)
    {
        Color backgroundColor = e.IsToggled ? Color.FromArgb("#153C64") : Colors.Transparent;
        Color knobColor = e.IsToggled ? Color.FromArgb("#D9D9D9") : Color.FromArgb("#2F6D80");
        customSwitch.Background = new SolidColorBrush(backgroundColor);
        customSwitch.KnobBackground = new SolidColorBrush(knobColor);
    }
   public void CustomSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Toggled?.Invoke(sender, e);
    }
}

