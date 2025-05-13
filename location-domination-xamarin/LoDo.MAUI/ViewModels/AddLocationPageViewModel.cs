using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LoDo.MAUI.ViewModels;

public partial class AddLocationPageViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Image>? _sources;
    
    public ICommand CarouselItemTappedCommand => new Command<object>(OnAddImageCommand);
    
    public AddLocationPageViewModel()
    {
        Sources = new ObservableCollection<Image>();
        Sources.Add(new Image());
        Sources.Add(new Image());
        Sources.Add(new Image());
    }

    private async void OnAddImageCommand(object obj)
    {
        var borderRef = obj as Border;
        var neededImage = borderRef.Content as Image;
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
                if (!File.Exists(cachedFilePath))
                {
                    using var stream = await result.OpenReadAsync();
                    using var fileStream = File.Create(cachedFilePath);
                    await stream.CopyToAsync(fileStream);
                }
                    
                var imageSource = ImageSource.FromFile(cachedFilePath);
                    
                neededImage.Source = imageSource;
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