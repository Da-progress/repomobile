using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.Models
{
    public class Location : LocationLight
    {
        [JsonProperty("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("verificationTime")]
        public string VerificationTime { get; set; }

        [JsonProperty("creator")]
        public Player Creator { get; set; }

        [JsonProperty("loc_image")]
        public byte[] LocImage { get; set; }

        public void CopyProperties(LocationLight light)
        {
            Id = light.Id;
            Name = light.Name;
            Sport = light.Sport;
            Longitude = light.Longitude;
            Latitude = light.Latitude;
            Address = light.Address;
        }
    }
}
