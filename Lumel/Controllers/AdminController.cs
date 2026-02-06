using Lumel.Enums;
using Lumel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lumel.Controllers
{
    [ApiController]


    [Route("[controller]")]
    //[AdminOnly] TODO : Implement
    public class AdminController : ControllerBase
    {
        [HttpPut]
        [Route("SetInventoryCount")]
        public ActionResult SetInventoryCount(InventoryType type/*TODO change this to dynamic so that we can support unlimiter inventory type support*/
            , int Count)
        {
            InventoryService.SetCount(type,Count);
            return Ok(InventoryService.GetStatus(type));

        }
        [HttpGet]
        [Route("InventotyStatus")]
        public ActionResult InventotyStatus(InventoryType type = InventoryType.FlashSale)
        {
            var result = InventoryService.GetStatus(type);
            return Ok(result);
        }
    }
}
