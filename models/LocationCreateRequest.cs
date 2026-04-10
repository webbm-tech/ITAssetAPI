public class LocationCreateRequest
{
    public int BuildingID { get; set; }
    public int RoomTypeID { get; set; }
    public required string RoomNumber { get; set; }
}