namespace LoDo.MAUI.Models.DTOs;

public class SportDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string IconName { get; set; } = string.Empty;
    public int RecordVersion { get; set; }
    public string Rules { get; set; } = string.Empty;
}
