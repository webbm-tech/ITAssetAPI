using Microsoft.EntityFrameworkCore;
public class ITAssetDbContext : DbContext
{
    public ITAssetDbContext (DbContextOptions<ITAssetDbContext>options) : base(options){}

//reference to table in DB
    public DbSet<ITAsset> ITAssets {get; set;} 
}