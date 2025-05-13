using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.Models
{
    public class Game : ObservableObject
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("hostPlayer")]
        public Player HostPlayer { get; set; }

        [JsonProperty("guestPlayer")]
        public Player GuestPlayer { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("hostScore")]
        public int? HostScore { get; set; }

        [JsonProperty("guestScore")]
        public int? GuestScore { get; set; }

        [JsonProperty("gameState")]
        public string GameState { get; set; }

        [JsonProperty("creationDateTime")]
        public DateTime CreationDateTime { get; set; }

        [JsonProperty("acceptDateTime")]
        public DateTime? AcceptDateTime { get; set; }

        [JsonProperty("resultRecordDateTime")]
        public DateTime? ResultRecordDateTime { get; set; }

        [JsonProperty("executionDateTime")]
        public DateTime? ExecutionDateTime { get; set; }

        [JsonProperty("verifiedDateTime")]
        public DateTime? VerifiedDateTime { get; set; }

        [JsonProperty("appointment1")]
        public DateTime? Appointment1 { get; set; }

        [JsonProperty("appointment2")]
        public DateTime? Appointment2 { get; set; }

        [JsonProperty("appointment3")]
        public DateTime? Appointment3 { get; set; }

        [JsonProperty("hasHostMadeAppointments")]
        public bool HasHostMadeAppointments { get; set; }

        [JsonProperty("hasHostSuggestedResult")]
        public bool HasHostSuggestedResult { get; set; }

        [JsonProperty("countForLeaderBoard")]
        public bool CountForLeaderBoard { get; set; }

        [JsonProperty("eventSport")]
        public EventSport EventSport { get; set; }

        [JsonProperty("recordVersion")]
        public int RecordVersion { get; set; }

        [JsonProperty]
        public bool IsOpenGameState => "OPEN".Equals(GameState);

        [JsonIgnore]
        public string Score
        {
            get
            {
                if (HostScore == null)
                    return null;

                if (GuestScore == null)
                    return HostScore + ":" + "Anonimous";

                return HostScore + ":" + GuestScore;
            }
        }

        [JsonIgnore]
        public Sport Sport => Location != null ? Location.Sport : EventSport?.Sport;

        public static implicit operator Game(Task<Game> v)
        {
            throw new NotImplementedException();
        }
    }
}
