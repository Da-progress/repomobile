using Newtonsoft.Json;

namespace LoDo.MAUI.Models.DTOs;

public class RegistrationDTO
{
    [JsonProperty("firebaseUserDeviceToken")]
    public string FireBaseToken { get; set; }
    [JsonProperty("mobileNr")]
    public string MobileNr { get; set; }
    [JsonProperty("username")]
    public string Username { get; set; }
    [JsonProperty("password")]
    public string Password { get; set; }
}