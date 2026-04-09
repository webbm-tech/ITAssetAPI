using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class EquipmentController : ControllerBase
{
    private ITAssetDbContext iTAssetDbcontext;

    public EquipmentController(ITAssetDbContext context)
    {
        this.iTAssetDbcontext = context;
    }

    // your action methods go here

    [HttpPost]
    public ActionResult<Equipment> CreateEquipment(EquipmentCreateRequest request)
    {
        try
        {
            Equipment equipment = new Equipment();
            equipment.EquipmentName = request.EquipmentName;
            equipment.EquipmentModel = request.EquipmentModel;
            equipment.SerialNumber = request.SerialNumber;
            equipment.ServiceTag = request.ServiceTag;
            equipment.OtherIDNumber = request.OtherIDNumber;
            equipment.EquipmentTypeID = request.EquipmentTypeID;
            equipment.EquipmentBrandID = request.EquipmentBrandID;
            equipment.EquipmentStatusID = request.EquipmentStatusID;
            equipment.LocationID = request.LocationID;

            iTAssetDbcontext.Equipment.Add(equipment);
            iTAssetDbcontext.SaveChanges();

            return CreatedAtAction(nameof(GetEquipmentById), new { id = equipment.EquipmentID }, equipment);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Equipment>> GetAllEquipment()
    {
        try
        {
            return Ok(iTAssetDbcontext.Equipment.ToList());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{equipmentID}")]
    public ActionResult<Equipment> GetEquipmentById(int equipmentID)
    {
        var equipment = iTAssetDbcontext.Equipment.Find(equipmentID);
        if (equipment == null)
            return NotFound();
        return Ok(equipment);
    }

    [HttpGet("/equipment/location/{locationID}")]
    public ActionResult<Equipment> GetEquipmentByLocation(int locationID)
    {
        var equipment = iTAssetDbcontext.Equipment.Find(locationID);
        if (equipment == null)
            return NotFound();
        return Ok(equipment);
    }

[HttpGet("unassigned")]
public ActionResult<IEnumerable<Equipment>> GetEquipmentWithoutLocation()
{
    try
    {
        var unassigned = iTAssetDbcontext.Equipment
            .Where(e => e.LocationID == null)
            .ToList();

        return Ok(unassigned);
    }
    catch (Exception ex)
    {
        return StatusCode(500, ex.Message);
    }
}

    [HttpPut("{equipmentID}/status")]
    public ActionResult<Equipment> ChangeEquipmentStatusByID(int equipmentID, [FromBody] EquipmentStatusUpdateRequest request)
    {
        try
        {
            var equipment = iTAssetDbcontext.Equipment.Find(equipmentID);
            if (equipment == null)
                return NotFound();

            equipment.EquipmentStatusID = request.EquipmentStatusID;
            iTAssetDbcontext.SaveChanges();

            return Ok(equipment);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}