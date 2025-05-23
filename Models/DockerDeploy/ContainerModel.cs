namespace OneApp_minimalApi.Models;

public class ContainerModel
{
    public string Id { get; set; }
    public string Command { get; set; }
    public string CreatedAt { get; set; }
    public string Image { get; set; }
    public string Labels { get; set; }
    public string LocalVolumes { get; set; }
    public string Mounts { get; set; }
    public string Networks { get; set; }
    public string Ports { get; set; }
    public string RunningFor { get; set; }
    public string Size { get; set; }
    public string Status { get; set; }
    public string Names { get; set; }
}