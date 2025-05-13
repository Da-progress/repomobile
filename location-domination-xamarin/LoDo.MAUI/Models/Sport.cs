using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.Models
{
    public class Sport : ObservableObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("iconName")]
        public string IconName { get; set; }

        [JsonProperty("rules")]
        public string Rules { get; set; }
    }
}
