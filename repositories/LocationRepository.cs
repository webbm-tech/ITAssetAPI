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
    /// Retreives a location in the database by location ID
    /// </summary>
    /// <param name="locationID"> The ID of the location </param>
    /// <returns> a location</returns>
    public Location GetLocationById(int locationID)
    {
        return iTAssetDbcontext.Locations
        .Include(location => location.Building)
        .Include(location => location.RoomType)
        .FirstOrDefault(location => location.LocationID == locationID);
    }


    /// <summary>
    /// Retreives all locations in a specified building
    /// </summary>
    /// <param name="buildingID"> ID of the buildng requested</param>
    /// <returns>A IEnumerable containing all of the locations in a specified building</returns>
    public IEnumerable<Location> GetLocationsByBuilding(int buildingID)
    {
        return iTAssetDbcontext.Locations
            .Where(l => l.BuildingID == buildingID)
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