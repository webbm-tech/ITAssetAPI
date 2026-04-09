using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        try
        {
            return Ok(iTAssetDbcontext.Locations
                .Include(l => l.Building)
                .Include(l => l.RoomType)
                .ToList());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
        }
    }

    [HttpGet("{locationID}")]
    public ActionResult<Location> GetLocationById(int locationID)
    {
        try
        {
            var location = iTAssetDbcontext.Locations
                .Include(l => l.Building)
                .Include(l => l.RoomType)
                .FirstOrDefault(l => l.LocationID == locationID);

            if (location == null)
                return NotFound();

            return Ok(location);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
        }
    }

    [HttpGet("building/{buildingID}")]
    public ActionResult<IEnumerable<Location>> GetLocationsByBuilding(int buildingID)
    {
        try
        {
            var locations = iTAssetDbcontext.Locations
                .Include(l => l.Building)
                .Include(l => l.RoomType)
                .Where(l => l.BuildingID == buildingID)
                .ToList();

            if (!locations.Any())
                return NotFound();

            return Ok(locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
        }
    }

    [HttpPost]
    public ActionResult<Location> CreateLocation(LocationCreateRequest request)
    {
        try
        {
            Location location = new Location();
            location.RoomNumber = request.RoomNumber;
            location.BuildingID = request.BuildingID;
            location.RoomTypeID = request.RoomTypeID;

            iTAssetDbcontext.Locations.Add(location);
            iTAssetDbcontext.SaveChanges();

            return CreatedAtAction(nameof(GetLocationById), new { locationID = location.LocationID }, location);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
        }
    }
}
