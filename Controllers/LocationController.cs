using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private LocationRepository locationRepository;

    public LocationController(LocationRepository locationRepository)
    {
        this.locationRepository = locationRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Location>> GetAllLocations()
    {
        return Ok(
            locationRepository.GetLocations()
        );
    }

   [HttpGet("{locationID}")]
    public ActionResult<Location> GetLocationById(int locationID)
    {   var location = locationRepository.GetLocationById(locationID);
        if (location == null)
            return NotFound();
        return locationRepository.GetLocationById(locationID);
    }

    [HttpGet("building/{buildingID}")]
    public ActionResult <IEnumerable<Location>> GetLocationsByBuilding(int buildingID)
    {
        var locations = locationRepository.GetLocationsByBuilding(buildingID);
        if (!locations.Any())
            return NotFound();
        return Ok(locations);
    }

    [HttpPost]
    public ActionResult<Location> CreateLocation(LocationCreateRequest request)
    {
        try
        {
            Location location = locationRepository.CreateLocation(request);
            return CreatedAtAction("CreateLocation", new { locationID = location.LocationID }, location);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
        }
    }
}
