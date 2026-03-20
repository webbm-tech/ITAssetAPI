using Microsoft.AspNetCore.Mvc;

[ApiController]
public class BuildingController : ControllerBase
{
    [HttpGet("/building/{buildingID}")]
    public Building GetBuildingById(int buildingID)
    {
       
        Building building1 = new Building
         { BuildingID = 1, BuildingName = "Bora Learning Center", Abbreviation = "BLC"};

        return building1;

    }

    
}
