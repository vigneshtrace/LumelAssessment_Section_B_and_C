using Lumel.Models;

namespace Lumel.Services
{
    public class InventoryLiveInfo
    {
        public int totalCount { get; set; }
        public List<TicketInfo> reservedList { get; set; }
        public Queue<int> waitingList { get; set; }
        public static readonly int defaultCount = 5;
        public static InventoryLiveInfo GetDefault()
        {
            return new InventoryLiveInfo()
            {
                totalCount = defaultCount,
                waitingList = new Queue<int>(),
                reservedList = new List<TicketInfo>()
            };
        }
        public int GetCurrentCount() => totalCount - reservedList.Count;
    }
}
