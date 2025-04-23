using System.ComponentModel.DataAnnotations;

namespace fc_minimalApi.Models;

public class DD_Threads : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Url { get; set; }
    public string? MainTitle { get; set; }
    public string? Type { get; set; }
    
    public ICollection<DD_LinkEd2k?> LinkEd2Ks { get; } // Collection navigation containing dependents

}