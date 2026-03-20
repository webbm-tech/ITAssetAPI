public class Location
{
    public int LocationID {get; set;} // Primary Key
    public string RoomNumber {get; set;}

    //Relational Data
    public int BuildingID {get; set;}
    public int RoomTypeID {get; set;}

}