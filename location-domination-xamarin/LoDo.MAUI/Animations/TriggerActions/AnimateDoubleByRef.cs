using AlohaKit.Animations;
using AlohaKit.Animations.Helpers;

namespace LoDo.MAUI.Animations.TriggerActions;

public class AnimateDoubleByRef : AnimationBaseTrigger<double>
{
    public VisualElement TargetViewName { get; set; }
    protected override async void Invoke(VisualElement sender)
    {
        if (TargetViewName == null)
            throw new NullReferenceException("Target view is null");
        AnimateDoubleByRef animateDouble = this;
        if (animateDouble.TargetProperty == null)
            throw new NullReferenceException("Null Target property.");
        if (animateDouble.Delay > 0)
            await Task.Delay(animateDouble.Delay);
        animateDouble.SetDefaultFrom((double) TargetViewName.GetValue(animateDouble.TargetProperty));
        TargetViewName.Animate(nameof (AnimateDouble) + animateDouble.TargetProperty.PropertyName, new Animation((Action<double>) (progress => TargetViewName.SetValue(this.TargetProperty, (object) AnimationHelper.GetDoubleValue(this.From, this.To, progress)))), length: animateDouble.Duration, easing: EasingHelper.GetEasing(animateDouble.Easing));
    }
}