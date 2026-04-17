using System;
using System.ComponentModel.DataAnnotations;

public class BuildingCreateRequest
{
    [Required(ErrorMessage = "Building name is required.")]
    public required string BuildingName {get; set;}
    
    [Required(ErrorMessage = "Abbreviation is required.")]
    public required string Abbreviation {get; set;}
}