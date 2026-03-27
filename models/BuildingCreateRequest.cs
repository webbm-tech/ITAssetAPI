using System.ComponentModel.DataAnnotations;

public class BuildingCreateRequest
{
    [Required]
    public string BuildingName {get; set;}
    
    [Required]
    public string Abbreviation {get; set;}
}