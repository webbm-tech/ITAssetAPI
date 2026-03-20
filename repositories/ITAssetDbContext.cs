using Microsoft.EntityFrameworkCore;
public class ITAssetDbContext : DbContext
{
    public ITAssetDbContext (DbContextOptions<ITAssetDbContext>options) : base(options){}

//reference to table in DB
    public DbSet<Building> Buildings {get; set;}
    public DbSet<Location> Locations {get; set;}
    public DbSet <RoomType> RoomTypes {get; set;}
    
}