using Microsoft.EntityFrameworkCore;

public class LocationRepository
{
    private ITAssetDbContext iTAssetDbcontext;

    public LocationRepository(ITAssetDbContext context)
    {
        this.iTAssetDbcontext = context;
    }

    /// <summary>
    /// Retrieves all locations in the database. 
    /// </summary>
    /// <returns>A IEnumerable containing all locations.</returns>
    public IEnumerable<Location> GetLocations()
    {
        return iTAssetDbcontext.Locations
        .Include(location => location.Building)
        .Include(location => location.RoomType)
        .ToList();
    }

    /// <summary>
    /// Saves a new location to the database, given a valid LocationCreateRequest.
    /// </summary>
    /// <param name="request">The valid LocationCreateRequest to persist.</param>
    /// <returns>The created Location to return, with its ID.</returns>
    public Location CreateLocation(LocationCreateRequest request)
    {
        // Map our request to our internal Location
        Location location = new Location();
        location.RoomNumber = request.RoomNumber;
        location.BuildingID = request.BuildingID;
        location.RoomTypeID = request.RoomTypeID;

        // Save location to the database
        iTAssetDbcontext.Locations.Add(location);
        iTAssetDbcontext.SaveChanges();

        return location;
    }


}