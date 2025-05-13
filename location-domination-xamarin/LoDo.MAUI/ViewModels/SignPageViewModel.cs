using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Auth;
using LoDo.MAUI.Views.Popups;
using Mopups.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LoDo.MAUI.Models.App;
using LoDo.MAUI.Models.DTOs;
using LoDo.MAUI.Services.Implementations;
using LoDo.MAUI.Services.Interfaces;
using Mopups.Services;
using Refit;

namespace LoDo.MAUI.ViewModels
{
    public partial class SingPageViewModel : ObservableObject
    {
        private CacheService _cacheService;
        private IPopupNavigation _popupService;
        private FirebaseAuthClient _client;
        private ILoDoApi _api;

        [ObservableProperty] private RegistrationModel _registrationModel = new RegistrationModel();

        [ObservableProperty] private string _copyOfPassword;

        [ObservableProperty] private string _errorRegText = "";

        [ObservableProperty] private bool _isBusy = false;
        
        private ICommand _signUpCommand;

        public ICommand SignUpCommand
        {
            get => _signUpCommand;
        }

        private ICommand _clearInputsCommand;

        public ICommand ClearInputsCommand
        {
            get => _clearInputsCommand;
        }
        
        public ICommand GoToLogin => new Command(OnSignIn);
        
        public SingPageViewModel(FirebaseAuthClient client, IPopupNavigation popupNavigation, ILoDoApi _api, CacheService cacheService)
        {
            this._api = _api;
            _client = client;
            _popupService = popupNavigation;
            _cacheService = cacheService;
            _signUpCommand = new Command(OnSignUp);
            _clearInputsCommand = new Command(ClearInputs);
           
        }
        

        private async void OnSignIn()
        {
           await Shell.Current.GoToAsync("//LoginPage", true);
        }

        private async void OnSignUp()
        {
            await MopupService.Instance.PushAsync(new AuthorizePopup(_api, 322));
            return;
            string cause = string.Empty;
            try
            {
                if(IsBusy)
                    return;
                IsBusy = true;
                var handler = new LoDo.MAUI.Helpers.Http.AuthenticatedHttpClientHandler("testuser", "testpass");

                var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri("http://app.ldomination.com:8081/api")
                };

                _api = RestService.For<ILoDoApi>(httpClient);
                var regData = RegistrationModel;
                if (!regData.CheckIfNotEmpty())
                {
                    throw new Exception("All fields are required");
                }

                if (!regData.CheckIfPasswordsMatch())
                {
                    throw new Exception("Passwords do not match");
                }

                if (!regData.CheckIfEmailIsValid())
                {
                    throw new Exception("Email is not valid");
                }

                if (!regData.CheckIfPhoneNumberIsValid())
                {
                    throw new Exception("Phone number is not valid");
                }

                if (regData.Password.Length < 6)
                {
                    throw new Exception("Password must be at least 6 characters long");
                }

                var model = new RegistrationDTO()
                {
                    FireBaseToken = string.Empty,
                    Password = regData.Password,
                    Username = regData.FirstName + regData.LastName,
                    MobileNr = regData.PhoneNumber,
                };
                var stringRep = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var result = await _api.Register(model);
                if (result.Duplicate)
                {
                    throw new Exception("Credentials are not valid");
                }

                Preferences.Set("isLoggedIn", true);
                _cacheService.SaveObject("userData", result);
                _cacheService.SaveObject("regDto", RegistrationModel);
                IsBusy = false;
                var authPopup = new AuthorizePopup(_api,(int)result.RegisteredPlayer.Id);
                await MopupService.Instance.PushAsync(authPopup);
                var flag = await authPopup.PopupDismissedTask;
                if (flag)
                {
                    App.Current.MainPage = new AppShell();
                }
                else
                {
                    throw new Exception("Something went wrong");
                }
            }
            catch (Refit.ApiException ex)
            {
                ErrorRegText = "Something went wrong, try again later";
                IsBusy = false;
            }
            catch (Exception ex)
            {
                ErrorRegText = ex.Message;
                IsBusy = false;
            }
        }

        private void ClearInputs()
        {
            // Email = string.Empty;
            // Password = string.Empty;
            // CopyOfPassword = string.Empty;
            // ErrorLogText = string.Empty;
            // ErrorRegText = string.Empty;
            // RememberUser = false;
        }
    }
}