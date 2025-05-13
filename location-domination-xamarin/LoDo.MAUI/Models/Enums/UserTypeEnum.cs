using Newtonsoft.Json;

namespace LoDo.MAUI.Models.Enums;

public enum UserTypeEnum
{
    [JsonProperty("PLAYER")] PLAYER,

    [JsonProperty("PORTAL_USER")] PORTAL_USER
}