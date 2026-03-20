using Microsoft.AspNetCore.Mvc;

public class EquipmentController : ControllerBase
{
    private ITAssetDbContext iTAssetDbContext;

    public EquipmentController (ITAssetDbContext context)
    {
        this.iTAssetDbContext = context;
    }

    [HttpPost("/equipment")]
    public Equipment CreateEquipment (Equipment equipment)
    {
        
    }
}