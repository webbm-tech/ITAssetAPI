public class Equipment
{
    public int EquipmentID {get; set;}
    public string EquipmentName {get; set;}
    public string EquipmentModel {get; set;}
    public string SerialNumber {get; set;}
    public string? ServiceTag {get; set;}
    public string? OtherIDNumber {get;set;}
    
    //Relational Data
    public int EquipmentTypeID {get;set;}
    public EquipmentType EquipmentType {get; set;}

    public int EquipmentBrandID {get; set;}
    public EquipmentBrand EquipmentBrand {get; set;}

    public int EquipmentStatusID {get; set;}
    public EquipmentStatus EquipmentStatus {get; set;}

    public int LocationID {get; set;}
    public Location Location {get; set;}
}