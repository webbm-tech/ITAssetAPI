using Microsoft.EntityFrameworkCore;
public class ITAssetDbContext : DbContext
{
    public ITAssetDbContext (DbContextOptions<ITAssetDbContext>options) : base(options){}

//reference to table in DB
    public DbSet<Building> Buildings {get; set;}
    public DbSet<Location> Locations {get; set;}
    public DbSet <RoomType> RoomTypes {get; set;}
    
    public DbSet<EquipmentBrand> EquipmentBrands {get; set;}
    public DbSet<EquipmentStatus> EquipmentStatuses {get; set;}
    public DbSet<EquipmentType> EquipmentTypes {get; set;}
    public DbSet<Equipment> Equipment {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoomType>().HasData(
            new RoomType { RoomTypeID = 1, RoomTypeDescription = "Classroom" },
            new RoomType { RoomTypeID = 2, RoomTypeDescription = "Computer Lab" },
            new RoomType { RoomTypeID = 3, RoomTypeDescription = "Faculty Office" },
            new RoomType { RoomTypeID = 4, RoomTypeDescription = "Staff Office" },
            new RoomType { RoomTypeID = 5, RoomTypeDescription = "Conference Room" },
            new RoomType { RoomTypeID = 6, RoomTypeDescription = "Storage" },
            new RoomType { RoomTypeID = 7, RoomTypeDescription = "IT" }

        );

        modelBuilder.Entity<EquipmentStatus>().HasData(
            new EquipmentStatus { EquipmentStatusID = 1, StatusName = "Active", StatusDescription = "In use and operational" },
            new EquipmentStatus { EquipmentStatusID = 2, StatusName = "In Repair", StatusDescription = "Currently being serviced" },
            new EquipmentStatus { EquipmentStatusID = 3, StatusName = "In Storage", StatusDescription = "Not deployed" },
            new EquipmentStatus { EquipmentStatusID = 4, StatusName = "Retired", StatusDescription = "End of life" },
            new EquipmentStatus { EquipmentStatusID = 5, StatusName = "Missing", StatusDescription = "Location unknown" }
        );

        modelBuilder.Entity<EquipmentType>().HasData(
            new EquipmentType { EquipmentTypeID = 1, TypeName = "Desktop" },
            new EquipmentType { EquipmentTypeID = 2, TypeName = "Laptop" },
            new EquipmentType { EquipmentTypeID = 3, TypeName = "All-in-One" },
            new EquipmentType { EquipmentTypeID = 4, TypeName = "Printer" },
            new EquipmentType { EquipmentTypeID = 5, TypeName = "Interactive Display" },
            new EquipmentType { EquipmentTypeID = 6, TypeName = "Phone" },
            new EquipmentType { EquipmentTypeID = 7, TypeName = "Monitor" },
            new EquipmentType { EquipmentTypeID = 8, TypeName = "PC Module" }
        );

        modelBuilder.Entity<EquipmentBrand>().HasData(
            new EquipmentBrand { EquipmentBrandID = 1, BrandName = "Dell" },
            new EquipmentBrand { EquipmentBrandID = 2, BrandName = "HP" },
            new EquipmentBrand { EquipmentBrandID = 3, BrandName = "Lenovo" },
            new EquipmentBrand { EquipmentBrandID = 4, BrandName = "Apple" },
            new EquipmentBrand { EquipmentBrandID = 5, BrandName = "ClearTouch" },
            new EquipmentBrand { EquipmentBrandID = 6, BrandName = "Poly" },
            new EquipmentBrand { EquipmentBrandID = 7, BrandName = "Bizhub" },
            new EquipmentBrand { EquipmentBrandID = 8, BrandName = "Kyocera" }
        );
    }
}