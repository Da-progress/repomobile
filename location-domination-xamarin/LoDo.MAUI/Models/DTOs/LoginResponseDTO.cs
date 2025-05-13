namespace LoDo.MAUI.Models.DTOs;

public class LoginResponseDTO
{
    public int CountLogin { get; set; }
    public string ErrorMessage { get; set; }
    public UserDTO Player { get; set; }
    public bool Success { get; set; }
}