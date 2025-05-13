using CommunityToolkit.Mvvm.ComponentModel;

namespace LoDo.MAUI.Models.App;

public partial class RegistrationModel : ObservableObject
{
    [ObservableProperty] private string _firstName = string.Empty;
    [ObservableProperty] private string _lastName = string.Empty;
    [ObservableProperty] private string _phoneNumber = string.Empty;
    [ObservableProperty] private string _email = string.Empty;
    [ObservableProperty] private string _password = string.Empty;
    [ObservableProperty] private string _confirmPassword = string.Empty;

    public bool CheckIfNotEmpty()
    {
        return !string.IsNullOrWhiteSpace(_firstName) && !string.IsNullOrWhiteSpace(_lastName) &&
               !string.IsNullOrWhiteSpace(_phoneNumber) && !string.IsNullOrWhiteSpace(_email) &&
               !string.IsNullOrWhiteSpace(_password) && !string.IsNullOrWhiteSpace(_confirmPassword);
    }
    public bool CheckIfPasswordsMatch()
    {
        return _password == _confirmPassword;
    }
    
    public bool CheckIfEmailIsValid()
    {
        return _email.Contains("@");
    }
    public bool CheckIfPhoneNumberIsValid()
    {
        return _phoneNumber.Length >= 10;
    }
}