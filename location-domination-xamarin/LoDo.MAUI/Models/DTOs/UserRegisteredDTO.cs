namespace LoDo.MAUI.Models.DTOs;

public class UserRegisteredDTO
{
    public bool Duplicate { get; set; }
    public string Message { get; set; }
    public UserDTO RegisteredPlayer { get; set; }
}