using System;
using System.ComponentModel.DataAnnotations;

public class Building
{
    public int BuildingID {get; set;}

    [Required(ErrorMessage = "Building name is required.")]
    public required string BuildingName {get; set;}

    [Required(ErrorMessage = "Building Abbreviation is required.")]
    public required string Abbreviation {get; set;}
}