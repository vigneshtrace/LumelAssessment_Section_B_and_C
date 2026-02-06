using Microsoft.EntityFrameworkCore;

namespace Lumel.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<DeliveryAudit> deliveryLog { get; set; }
    }
}
