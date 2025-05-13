using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using LoDo.MAUI.Models.App;
using LoDo.MAUI.Models.DTOs;
using LoDo.MAUI.Services.Implementations;
using LoDo.MAUI.Services.Interfaces;

namespace LoDo.MAUI.ViewModels;
//TODO: 
// -Implement usage of actual user data.
// -Implement saving of new user data.
// -Add validation to fields.
public partial class EditProfilePageViewModel : ObservableObject
{
    private CacheService _cacheService;
    private ILoDoApi _api;
    
    [ObservableProperty] private string _firstName;
    [ObservableProperty] private string _lastName;
    [ObservableProperty] private string _email;
    [ObservableProperty] private string _phone;
    [ObservableProperty] private string _address;
    [ObservableProperty] private string _city;
    [ObservableProperty] private string _postalCode;
    [ObservableProperty] private bool _isBusy = false;
    [ObservableProperty] private string _greetings;

    public ICommand SaveCommand => new Command(OnSaveCommand);
    public ICommand UpdateImageCommand => new Command(OnUpdateImageCommand);
    
    public Image AvatarImage { get; set; }
    
    public EditProfilePageViewModel(CacheService cacheService, ILoDoApi api)
    {
        _cacheService = cacheService;
        _api = api;
        try
        {
            SetUpData();
        }
        catch (Exception ex)
        {
            
        }
    }

    private void SetUpData()
    {
        var data = _cacheService.GetObject<UserRegisteredDTO>("userData");
        Greetings = $"Welcome, {data.RegisteredPlayer.Username}";
        var userdata = _cacheService.GetObject<RegistrationModel>("regDto");
        if(userdata == null)
            return;
        var adressData = _cacheService.GetObject<AddressDTO>("address");
        FirstName = userdata.FirstName;
        LastName = userdata.LastName;
        Email = userdata.Email;
        Phone = userdata.PhoneNumber;
        if (adressData != null)
        {
            City = adressData.City;
            PostalCode = adressData.Postcode;
            Address = adressData.Street;
        }
    }
    
    private async void OnSaveCommand()
    {
        if(IsBusy)
            return;
        IsBusy = true;
        var newData = new RegistrationModel()
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            Email = this.Email,
            PhoneNumber = this.Phone,
        };
        _cacheService.SaveObject("regDto", newData);
        var newAddress = new AddressDTO()
        {
            City = this.City,
            Postcode = this.PostalCode,
            Street = this.Address,
        };
        _cacheService.SaveObject("address", newAddress);
        IsBusy = false;
    }

    private async void OnUpdateImageCommand()
    {
            try
            {
                var result = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "Select an Image",
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    string cacheDir = Path.Combine(FileSystem.CacheDirectory, "images");
                    Directory.CreateDirectory(cacheDir);
                    
                    string fileName = Path.GetFileName(result.FullPath);
                    string cachedFilePath = Path.Combine(cacheDir, fileName);
                    Preferences.Default.Set<string>("avatar",cachedFilePath);
                    
                    if (!File.Exists(cachedFilePath))
                    {
                        using var stream = await result.OpenReadAsync();
                        using var fileStream = File.Create(cachedFilePath);
                        await stream.CopyToAsync(fileStream);
                    }
                    
                    var imageSource = ImageSource.FromFile(cachedFilePath);
                    
                    AvatarImage.Source = imageSource;
                    Preferences.Set("avatarChanged", true);
                }
                else
                {
                    Console.WriteLine("No image selected.");
                }
            }
            catch (Exception ex)
            {
                // Handle errors (e.g., user canceled)
                Console.WriteLine($"Error picking image: {ex.Message}");
            }
    }
}