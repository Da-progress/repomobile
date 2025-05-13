using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.Models
{
    public class LoginResponseDto : ObservableObject
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("player")]
        public Player Player { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("countLogin")]
        public int CountLogin { get; set; }
    }
}
