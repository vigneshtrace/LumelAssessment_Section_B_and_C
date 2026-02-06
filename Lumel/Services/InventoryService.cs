using Lumel.Enums;
using Lumel.Models;

namespace Lumel.Services
{
    public class InventoryService //Inject this as a service
    {
        public static Dictionary<InventoryType, InventoryLiveInfo> data = new Dictionary<InventoryType, InventoryLiveInfo>()
        {

            [InventoryType.FlashSale] = InventoryLiveInfo.GetDefault()

        };
        public static Dictionary<InventoryType, object> sharedLock = new Dictionary<InventoryType, object>()
        {
            [InventoryType.FlashSale] = new object()
        };

        public static TicketInfo Reserve(InventoryType type, int userId)
        {
            lock (sharedLock[type])
            {
                var live = data[type];
                if (live.GetCurrentCount() > 0)
                {
                    var ticket = TicketInfo.Create(userId);
                    live.reservedList.Add(ticket);
                    return (ticket);
                }
                live.waitingList.Enqueue(userId);
            }
            return default(TicketInfo) ;
        }
        public static void SetCount(InventoryType type, int count)//move to separate service so that developer will not mistakenly breach this action
        {
            lock (sharedLock[type])
            {
                var live = data[type];

                live.totalCount = count;
                while (live.GetCurrentCount() > 0 && live.waitingList.Count > 0)
                {
                    var userId = live.waitingList.Dequeue();
                    live.reservedList.Add(TicketInfo.Create(userId));
                }
            }
        }
        public static object GetStatus(InventoryType type)//move to separate service so that developer will not mistakenly breach this action
        {
            lock (sharedLock[type])
            {
                var live = data[type];
                return new
                {
                    totalCount = live.totalCount,
                    reservedCount = live.reservedList.Count,
                    waitingListCount = live.waitingList.Count
                };

            }
        }
    }
}
