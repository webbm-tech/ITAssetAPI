using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private ITAssetDbContext iTAssetDbcontext;

    public LocationController(ITAssetDbContext context)
    {
        this.iTAssetDbcontext = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Location>> GetAllLocations()
    {
        return Ok(iTAssetDbcontext.Locations.ToList());
    }

    [HttpGet("{locationID}")]
    public ActionResult<Location> GetLocationById(int locationID)
    {
        var location = iTAssetDbcontext.Locations.Find(locationID);
        if (location == null)
            return NotFound();
        return Ok(location);
    }

    [HttpGet("building/{buildingID}")]
    public ActionResult<IEnumerable<Location>> GetLocationsByBuilding(int buildingID)
    {
        var locations = iTAssetDbcontext.Locations
            .Where(l => l.BuildingID == buildingID)
            .ToList();
        if (!locations.Any())
            return NotFound();
        return Ok(locations);
    }
}
