using System;
using System.ComponentModel.DataAnnotations;

public class EquipmentStatus
{
    public int EquipmentStatusID {get; set;}
    
    [Required(ErrorMessage = "Status name is required.")]
    public required string StatusName {get; set;}
    public string? StatusDescription {get; set;}
}