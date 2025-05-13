using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.Models
{
    public class EventSport : ObservableObject
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }

        [JsonProperty("sport")]
        public Sport Sport { get; set; }
    }
}
