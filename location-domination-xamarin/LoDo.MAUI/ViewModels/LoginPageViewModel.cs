using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using LoDo.MAUI.Models;
using LoDo.MAUI.Models.App;
using LoDo.MAUI.Models.DTOs;
using LoDo.MAUI.Services.Implementations;
using LoDo.MAUI.Services.Interfaces;
using LoDo.MAUI.Views.Popups;
using Mopups.Services;
using Refit;

namespace LoDo.MAUI.ViewModels;

public partial class LoginPageViewModel : ModelBase
{
    private ILoDoApi _api;
    private CacheService _cacheService;
    
    [ObservableProperty] private RegistrationModel _registrationModel = new RegistrationModel();
    [ObservableProperty] private string _errorRegText = "";
    [ObservableProperty] private bool _isBusy = false;

    public ICommand LoginCommand => new Command(OnLoginCommand);

    public ICommand ForgotPasswordCommand => new Command(OnForgotPasswordCommand);

    public LoginPageViewModel(ILoDoApi api, CacheService cacheService)
    {
        _api = api;    
        _cacheService = cacheService;
    }

    private async void OnForgotPasswordCommand()
    {
        Vibrate();
        await MopupService.Instance.PushAsync(new ForgotPasswordPopup());
    }
    
    private async void OnLoginCommand()
    {
        try
        {
           // MopupService.Instance.PushAsync(new AuthorizePopup());
            if (IsBusy)
                return;
            IsBusy  = true;
            if(this.RegistrationModel.Password == string.Empty || this.RegistrationModel.PhoneNumber == string.Empty)
            {
                throw new Exception("All fields are required");
            }
            if (!this.RegistrationModel.CheckIfPhoneNumberIsValid())
            {
                throw new Exception("Invalid phone number");
            }
            var handler = new LoDo.MAUI.Helpers.Http.AuthenticatedHttpClientHandler("testuser", "testpass");

            var httpClient = new HttpClient(handler)
            {
                BaseAddress =  new Uri("http://app.ldomination.com:8081/api")
            };
            
            _api = RestService.For<ILoDoApi>(httpClient);

            var userInfo = await  _api.FindByPhoneNr(RegistrationModel.PhoneNumber);

            if (userInfo == null)
            {
                throw new Exception("User not found");
            }
            var response =  await _api.Login(new RegistrationDTO()
            {
                Password = RegistrationModel.Password,
                MobileNr = RegistrationModel.PhoneNumber,
                Username = userInfo.Username,
            });
            if (!response.Success)
            {
                throw new Exception("Credentials are not valid");
            }
            _cacheService.SaveObject("loginResponse", response);
            Preferences.Set("isLoggedIn", true);
            IsBusy = false;
           
        }
        catch (Exception ex)
        {
            ErrorRegText = ex.Message;
            IsBusy = false;
        }
    }

}