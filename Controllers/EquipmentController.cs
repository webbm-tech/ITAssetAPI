using Microsoft.AspNetCore.Mvc;

public class EquipmentController : ControllerBase
{
    private ITAssetDbContext iTAssetDbContext;

    public EquipmentController (ITAssetDbContext context)
    {
        this.iTAssetDbContext = context;
    }

    [HttpPost("/equipment")]
    public Equipment CreateEquipment (EquipmentCreateRequest request)
    {
        Equipment equipment = new Equipment();
        equipment.EquipmentName = request.EquipmentName;
        equipment.EquipmentModel = request.EquipmentModel;
        equipment.SerialNumber = request.SerialNumber;
        equipment.ServiceTag = request.ServiceTag;
        equipment.OtherIDNumber = request.OtherIDNumber;
        equipment.EquipmentTypeID = request.EquipmentTypeID;
        equipment.BrandID = request.BrandID;
        equipment.StatusID = request.StatusID;
        equipment.LocationID = request.LocationID;
        
        return equipment;
    }
}