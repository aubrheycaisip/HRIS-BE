using HRIS_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace HRIS_BE.Helpers.Models
{
    public class HRISDbContext : DbContext
    {
        public DbSet<DemoTable> DemoTable { get; set; }
        public HRISDbContext(DbContextOptions<HRISDbContext> options) : base(options)
        {

        }
    }
}
