using Microsoft.AspNetCore.Mvc;

[ApiController]
public class BuildingController : ControllerBase
{
    private ITAssetDbContext iTAssetDbcontext;

    public BuildingController (ITAssetDbContext context)
    {
        this.iTAssetDbcontext = context;
    }

    [HttpPost ("building")]
    public Building CreateBuilding (BuildingCreateRequest request)
    {
        if (!ModelState.IsValid)
        {
            throw new InvalidInputException("Invalid building create request", ModelState);
        }
        Building building = new Building();
        building.BuildingName = request.BuildingName;
        building.Abbreviation = request.Abbreviation;

        iTAssetDbcontext.Buildings.Add(building);
        iTAssetDbcontext.SaveChanges();

        return building;
    }

    [HttpGet("/building/{buildingID}")]
    public Building GetBuildingById(int buildingID)
    {
        return iTAssetDbcontext.Buildings.Find(buildingID);
    }

    
}
