using Lumel.Enums;
using Lumel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lumel.Controllers
{
    [ApiController]

    [Route("[controller]")]
    
    public class TicketController : ControllerBase
    {
        //settotal inventory
        //Reserve
        //Status
        [HttpPost]
        [Route("Reserve")]
        public ActionResult Reserve(int userId,InventoryType type = InventoryType.FlashSale)
        {
            var result = InventoryService.Reserve(type, userId);
            if (result != null)
                return Ok(result);
            return Ok("Waiting list");
        }
        
    }
}
