namespace LoDo.MAUI.Models.DTOs;

public class LocationLightDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public AddressDTO Address { get; set; } = new AddressDTO();
    public SportDTO Sport { get; set; } = new SportDTO();
}