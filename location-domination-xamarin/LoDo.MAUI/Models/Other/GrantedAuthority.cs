using Newtonsoft.Json;

namespace LoDo.MAUI.Models.Other;

public class GrantedAuthority
{
    [JsonProperty("authority")]
    public string Authority { get; set; }
}