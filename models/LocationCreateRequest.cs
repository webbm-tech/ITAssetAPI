using System;
using System.ComponentModel.DataAnnotations;
public class LocationCreateRequest
{
    public int BuildingID { get; set; }
    public int RoomTypeID { get; set; }

    [Required(ErrorMessage = "Room number is required.")]
    public required string RoomNumber { get; set; }
}