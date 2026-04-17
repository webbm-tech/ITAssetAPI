using System;
using System.ComponentModel.DataAnnotations;

public class Location
{
    public int LocationID {get; set;} // Primary Key
    
    [Required(ErrorMessage = "Room number is required.")]
    public required string RoomNumber {get; set;}

    //Relational Data
    public int BuildingID {get; set;}
    public Building? Building {get; set;}
    public int RoomTypeID {get; set;}
    public RoomType? RoomType {get; set;}
    

}