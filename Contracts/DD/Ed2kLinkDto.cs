namespace fc_minimalApi.Contracts.DD;

public class Ed2kLinkDto
{
    public int Id { get; set; }
    public string Ed2kLink { get; set; }
    public string Title { get; set; }
    public bool IsNew { get; set; }
    public bool IsUsed { get; set; }
    public int ThreadId { get; set; }
}