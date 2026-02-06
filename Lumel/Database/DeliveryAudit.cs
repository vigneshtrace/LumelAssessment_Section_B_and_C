using Lumel.Enums;

namespace Lumel.Database
{
    public class DeliveryAudit
    {
        public int id { get; set; }
        public int driverId { get; set; }
        public DeliveryStatus deliveryStatus { get; set; }
        public DateTime attemptDateTime { get; set; }
        public int monthValue { get; set; }
        public int yearValue { get; set; }
    }
}
