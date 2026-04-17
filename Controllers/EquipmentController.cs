using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class EquipmentController : ControllerBase
{
    private EquipmentRepository equipmentRepository;

    public EquipmentController(EquipmentRepository equipmentRepository)
    {
        this.equipmentRepository = equipmentRepository;
    }

    // your action methods go here

    /// <summary>
    /// Saves a new equipment to the database, given a valid EquipmentCreateRequest.
    /// </summary>
    /// <param name="request">The valid EquipmentCreateRequest to persist.</param>
    /// <returns>The created Equipment to return, with its ID.</returns>
    [HttpPost]
    public ActionResult<Equipment> CreateEquipment(EquipmentCreateRequest request)
    {
        try
        {
            Equipment equipment = equipmentRepository.CreateEquipment(request);
            return CreatedAtAction("CreateEquipment", new { equipmentID = equipment.EquipmentID }, equipment);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
        }
    }
}

//     [HttpGet]
//     public ActionResult<IEnumerable<Equipment>> GetAllEquipment()
//     {
//         try
//         {
//             return Ok(iTAssetDbcontext.Equipment.ToList());
//         }
//         catch (Exception ex)
//         {
//             return StatusCode(500, ex.Message);
//         }
//     }

//     [HttpGet("{equipmentID}")]
//     public ActionResult<Equipment> GetEquipmentById(int equipmentID)
//     {
//         var equipment = iTAssetDbcontext.Equipment.Find(equipmentID);
//         if (equipment == null)
//             return NotFound();
//         return Ok(equipment);
//     }

//     [HttpGet("/equipment/location/{locationID}")]
//     public ActionResult<Equipment> GetEquipmentByLocation(int locationID)
//     {
//         var equipment = iTAssetDbcontext.Equipment.Find(locationID);
//         if (equipment == null)
//             return NotFound();
//         return Ok(equipment);
//     }

// [HttpGet("unassigned")]
// public ActionResult<IEnumerable<Equipment>> GetEquipmentWithoutLocation()
// {
//     try
//     {
//         var unassigned = iTAssetDbcontext.Equipment
//             .Where(e => e.LocationID == null)
//             .ToList();

//         return Ok(unassigned);
//     }
//     catch (Exception ex)
//     {
//         return StatusCode(500, ex.Message);
//     }
// }

//     [HttpPut("{equipmentID}/status")]
//     public ActionResult<Equipment> ChangeEquipmentStatusByID(int equipmentID, [FromBody] EquipmentStatusUpdateRequest request)
//     {
//         try
//         {
//             var equipment = iTAssetDbcontext.Equipment.Find(equipmentID);
//             if (equipment == null)
//                 return NotFound();

//             equipment.EquipmentStatusID = request.EquipmentStatusID;
//             iTAssetDbcontext.SaveChanges();

//             return Ok(equipment);
//         }
//         catch (Exception ex)
//         {
//             return StatusCode(500, ex.Message);
//         }
//     }
// }