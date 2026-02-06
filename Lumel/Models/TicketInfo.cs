namespace Lumel.Models
{
    public class TicketInfo
    {
        public int identityId { get; set; }
        public Guid reservationId { get; set; }
        public static TicketInfo Create(int identity)
        {
            return new TicketInfo()
            {
                identityId = identity,
                reservationId = Guid.NewGuid(),
            };
        }
    }
}
