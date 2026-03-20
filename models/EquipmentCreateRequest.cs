public class EquipmentCreateRequest
{
    public string EquipmentName {get; set;}
    public string EquipmentModel {get; set;}
    public string SerialNumber {get; set;}
    public string? ServiceTag {get; set;}
    public string? OtherIDNumber {get;set;}
    
    //Relational Data
    public int EquipmentTypeID {get;set;}
    public int BrandID {get; set;}
    public int StatusID {get; set;}
    public int LocationID {get; set;}
}