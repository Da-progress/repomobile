using CommunityToolkit.Mvvm.ComponentModel;
using LoDo.MAUI.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LoDo.MAUI.Models
{
    public class EventLight : ObservableObject
    {
        [Newtonsoft.Json.JsonIgnore]
        private readonly UtcToLocalZoneConverter DateConverter = new UtcToLocalZoneConverter();

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("startDateTime")]
        public DateTime StartDateTime { get; set; }

        [JsonProperty("endDateTime")]
        public DateTime EndDateTime { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string FromToDate
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("event light read date");

                var yy = ((DateTime)DateConverter.Convert(StartDateTime, null, null, null)).ToString("dd.MM.yyyy")
                         + " - " +
                         ((DateTime)DateConverter.Convert(EndDateTime, null, null, null)).ToString("dd.MM.yyyy");
                return yy;
            }
        }
    }
}
