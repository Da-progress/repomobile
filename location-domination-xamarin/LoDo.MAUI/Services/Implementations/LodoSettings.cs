using LoDo.MAUI.Services.Interfaces;

namespace LoDo.MAUI.Services.Implementations;

public class LodoSettings : ISettings
{
    private bool _shouldVibrate;

    public bool ShouldVibrate
    {
        get => _shouldVibrate;
        set => _shouldVibrate = value;
    }
}