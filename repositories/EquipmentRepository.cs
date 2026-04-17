using Microsoft.EntityFrameworkCore;

public class EquipmentRepository
{
    private ITAssetDbContext iTAssetDbcontext;

    public EquipmentRepository(ITAssetDbContext context)
    {
        this.iTAssetDbcontext = context;
    }


        public Equipment CreateEquipment(EquipmentCreateRequest request)
    {
        Equipment equipment = new Equipment();
        equipment.EquipmentName = request.EquipmentName;
        equipment.EquipmentModel = request.EquipmentModel;
        equipment.SerialNumber = request.SerialNumber;
        equipment.ServiceTag = request.ServiceTag;
        equipment.OtherIDNumber = request.OtherIDNumber;
        equipment.EquipmentTypeID = request.EquipmentTypeID;
        equipment.EquipmentBrandID = request.EquipmentBrandID;
        equipment.EquipmentStatusID = request.EquipmentStatusID;
        equipment.LocationID = request.LocationID;

        iTAssetDbcontext.Equipment.Add(equipment);
        iTAssetDbcontext.SaveChanges();

        return equipment;
        }
}