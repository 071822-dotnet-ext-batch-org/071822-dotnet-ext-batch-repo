using EFAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFAPI
{
    public class BatchContext : DbContext
    {
        public BatchContext(DbContextOptions<BatchContext> options) : base(options) { }

        public DbSet<Associate> Associates { get; set; }
    }
}
