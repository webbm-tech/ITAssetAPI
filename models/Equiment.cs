using System;
using System.ComponentModel.DataAnnotations;

public class Equipment
{
    public int EquipmentID {get; set;}
       
    [Required(ErrorMessage = "Equipment name is required.")]
    public required string EquipmentName {get; set;}

    [Required(ErrorMessage = "Equipment model is required.")]
    public required string EquipmentModel {get; set;}

    [Required(ErrorMessage = "Equipment serial number is required.")]
    public required string SerialNumber {get; set;}
    public string? ServiceTag {get; set;}
    public string? OtherIDNumber {get;set;}
    
    //Relational Data
    public int EquipmentTypeID {get;set;}
    public EquipmentType? EquipmentType {get; set;}

    public int EquipmentBrandID {get; set;}
    public EquipmentBrand? EquipmentBrand {get; set;}

    public int EquipmentStatusID {get; set;}
    public EquipmentStatus? EquipmentStatus {get; set;}

    public int LocationID {get; set;}
    public Location? Location {get; set;}
}