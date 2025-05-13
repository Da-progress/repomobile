using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.Models
{
    public class Event : EventLight
    {
        [JsonProperty("creationDateTime")]
        public DateTime CreationDateTime { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("creator")]
        public PortalUser Creator { get; set; }

        [JsonProperty("responsibleUser")]
        public PortalUser ResponsibleUser { get; set; }

        [JsonProperty("sponsorText")]
        public string SponsorText { get; set; }

        [JsonProperty("registrationCode")]
        public string RegistrationCode { get; set; }

        [JsonProperty("eventSports")]
        public List<EventSport> EventSports { get; set; }

        [JsonProperty("recordVersion")]
        public int RecordVersion { get; set; }
    }
}
