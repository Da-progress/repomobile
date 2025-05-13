using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoDo.MAUI.Models
{
    public class Address : ObservableObject
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("streetNumber")]
        public string StreetNumber { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonIgnore]
        public string StreetAndStreetNumber => Street + " " + StreetNumber;

        [JsonIgnore]
        public string PostcodeAndCity => Postcode + " " + City;

        [JsonIgnore]
        public string AddressFull
        {
            get
            {
                if (Street == null || StreetNumber == null || City == null)
                {
                    return "";
                }

                if (Street.Length == 0 || StreetNumber.Length == 0 || City.Length == 0)
                {
                    return "";
                }

                return Street + " " + StreetNumber + ", " + City;
            }
        }

        [JsonProperty("recordVersion")]
        public long RecordVersion { get; set; }
    }
}
