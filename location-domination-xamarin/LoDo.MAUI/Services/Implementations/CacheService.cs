using Newtonsoft.Json;

namespace LoDo.MAUI.Services.Implementations;

public class CacheService
{
    public void SaveObject<T>(string key, T data)
    {
        var json = JsonConvert.SerializeObject(data);
        Preferences.Set(key, json);
    }

    public T? GetObject<T>(string key)
    {
        var json = Preferences.Get(key, string.Empty);
        return string.IsNullOrEmpty(json) ? default : JsonConvert.DeserializeObject<T>(json);
    }
}