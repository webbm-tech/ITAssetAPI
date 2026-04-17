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

    /// <summary>
    /// Gets all locations 
    /// </summary>
    /// <returns> IEnumberable containing all locations</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Location>> GetAllLocations()
    {
        return Ok(
            locationRepository.GetLocations()
        );
    }

    /// <summary>
    /// Retreives a location in the database by location ID
    /// </summary>
    /// <param name="locationID"> The ID of the location </param>
    /// <returns> a location</returns>
   [HttpGet("{locationID}")]
    public ActionResult<Location> GetLocationById(int locationID)
    {   var location = locationRepository.GetLocationById(locationID);
        if (location == null)
            return NotFound();
        return locationRepository.GetLocationById(locationID);
    }

    /// <summary>
    /// Retreives all locations in a specified building
    /// </summary>
    /// <param name="buildingID"> ID of the buildng requested</param>
    /// <returns>A IEnumerable containing all of the locations in a specified building</returns>
    [HttpGet("building/{buildingID}")]
    public ActionResult <IEnumerable<Location>> GetLocationsByBuilding(int buildingID)
    {
        var locations = locationRepository.GetLocationsByBuilding(buildingID);
        if (!locations.Any())
            return NotFound();
        return Ok(locations);
    }

    /// <summary>
    /// Saves a new location to the database, given a valid LocationCreateRequest.
    /// </summary>
    /// <param name="request">The valid LocationCreateRequest to persist.</param>
    /// <returns>The created Location to return, with its ID.</returns>
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
