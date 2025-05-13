namespace LoDo.MAUI.Views.Related.Controls;

public class BorderWithShadow : Border
{
    public static readonly BindableProperty CustomTextColorProperty =
        BindableProperty.Create(
            nameof(ShadowEnabled),               // Property name
            typeof(bool),                         // Property type
            typeof(BorderWithShadow),
            defaultValue:true);

    // Property wrapper for the bindable property
    public bool ShadowEnabled
    {
        get => (bool)GetValue(CustomTextColorProperty);
        set => SetValue(CustomTextColorProperty, value);
    }

}