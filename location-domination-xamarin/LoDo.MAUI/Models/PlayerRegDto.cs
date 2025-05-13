using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.Models
{
    // PlayerRegistrationDto
    public class PlayerRegDto : ObservableObject
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("duplicate")]
        public bool Duplicate { get; set; }

        [JsonProperty("registeredPlayer")]
        public Player RegisteredPlayer { get; set; }
    }
}
