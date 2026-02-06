using Lumel.Database;
using Lumel.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lumel.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public DriversController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        [HttpGet]
        [Route("GetReliableDerivers")]
        ///
        /// In Production, I'll consiter having aggregation table which has monthly preaggregated data.
        /// Periodic Aggregation By driverId, by Monthly, By Yearly
        ///
        public async Task<ActionResult> GetReliableDerivers(int month, int year, int pageNumber = 1, int pageSize = 5)
        {
            int totalDeliverOfMonth = _dbContext
                .deliveryLog
                .Where(x => x.monthValue == month && x.yearValue == year)//instead of this, I'll use sql date function in the next TODO.
                .Count();
            var fetchedData = await _dbContext
                .deliveryLog
                .Where(x => x.monthValue == month && x.yearValue == year && x.deliveryStatus == Enums.DeliveryStatus.Completed)
                .GroupBy(x => x.driverId)
                .Select(x => new
                {
                    driverId = x.Key,
                    completedOrderCount = x.Count()
                })
                .OrderByDescending(x => x.completedOrderCount)
                .Skip((pageNumber -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            ;
            var result = fetchedData.
                Select(x => new
                {
                    driverId = x.driverId,
                    successRate = (totalDeliverOfMonth/x.completedOrderCount) * 100 
                });
            return Ok(result);

        }
        [HttpGet]
        [Route("CreateDeliveryLog")]
        public async Task<ActionResult> CreateDeliveryLog(int driverId, DeliveryStatus status, DateTime date)
        {
            _dbContext.deliveryLog.Add(new DeliveryAudit()
            {
                driverId = driverId,
                deliveryStatus = status,
                attemptDateTime = date,
                monthValue = date.Month,
                yearValue = date.Year
            });
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
