using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.Models
{
    public class User : ObservableObject
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("registerDateTime")]
        public DateTime RegisterDateTime { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        
        [JsonProperty("passwordHash")]
        public string Password { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("authenticated")]
        public bool Authenticated { get; set; }
    }
}
