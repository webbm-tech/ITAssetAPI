using System;
using System.ComponentModel.DataAnnotations;

public class RoomType
{
    public int RoomTypeID {get; set;}
    
    [Required(ErrorMessage = "Room type description is required.")]
    public required string RoomTypeDescription {get; set;}

}