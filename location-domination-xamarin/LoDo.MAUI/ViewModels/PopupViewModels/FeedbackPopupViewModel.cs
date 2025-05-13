using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LoDo.MAUI.ViewModels.PopupViewModels;

public partial class FeedbackPopupViewModel : ModelBase
{
    [ObservableProperty] private string _validationMessage = string.Empty;
    [ObservableProperty] private bool _isFeedback;
    [ObservableProperty] private bool _isBug;
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private string _emailAddress = string.Empty;
    [ObservableProperty] private string _description = string.Empty;

    public ICommand SubmitCommand => new Command(OnSubmit);
    public ICommand UpdateSelectionCommand => new Command<object>(OnUpdateSelection);

    private async void OnSubmit()
    {
        try
        {
            string info = IsBug ? "Bug" : "Feedback";
            var message = new EmailMessage
            {
                Subject = $"{info} from {Name}, {EmailAddress}",
                BodyFormat = EmailBodyFormat.PlainText,
                Body = Description,
                To = new List<string> { "support@ldomination.com" }
            };

           await Email.ComposeAsync(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during email sending: {ex.Message}");
        }
    }

    private void OnUpdateSelection(object obj)
    {
        var selection = obj as string;
        if (selection == "feedback")
        {
            IsFeedback = true;
            IsBug = false;
        }
        else
        {
            IsBug = true;
            IsFeedback = false;
        }
    }

    private void Validate()
    {
       
    }
}