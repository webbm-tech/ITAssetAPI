using System;
using System.ComponentModel.DataAnnotations;

public class EquipmentType
{
    public int EquipmentTypeID {get; set;}

    [Required(ErrorMessage = "Type name is required.")]
    public required string TypeName {get; set;}

}