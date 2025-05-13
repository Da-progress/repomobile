using Newtonsoft.Json;

namespace LoDo.MAUI.Models.DTOs;

public class AddressDTO
{
    [JsonProperty("city")]
    public string City { get; set; }
    
    [JsonProperty("country")]
    public string Country { get; set; }
    
    [JsonProperty("id")]
    public long Id { get; set; }
    
    [JsonProperty("postcode")]
    public string Postcode { get; set; }
    
    [JsonProperty("recordVersion")]
    public int RecordVersion { get; set; }
    
    [JsonProperty("street")]
    public string Street { get; set; }
    
    [JsonProperty("streetNumber")]
    public string StreetNumber { get; set; }
}