using Microsoft.AspNetCore.Mvc;

[ApiController]
public class BuildingController : ControllerBase
{
    private ITAssetDbContext iTAssetDbcontext;

    public BuildingController (ITAssetDbContext context)
    {
        this.iTAssetDbcontext = context;
    }
    [HttpGet("/building/{buildingID}")]
    public Building GetBuildingById(int buildingID)
    {
       
        Building building1 = new Building
         { BuildingID = 1, BuildingName = "Bora Learning Center", Abbreviation = "BLC"};

        return iTAssetDbcontext.Buildings.Find(buildingID);

    }

    
}
