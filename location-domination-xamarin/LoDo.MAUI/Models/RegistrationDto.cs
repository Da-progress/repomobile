using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.Models
{
    public class RegistrationDto : ObservableObject
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("mobileNr")]
        public string MobileNr { get; set; }

        [JsonProperty("firebaseUserDeviceToken")]
        public string FirebaseDeviceToken { get; set; }
    }
}
