using Microsoft.EntityFrameworkCore;
using PurseMvc.Models;

namespace PurseMvc.Data
{
    public class PurseMvcContext : DbContext
    {
        public PurseMvcContext(DbContextOptions<PurseMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Purse> Purse { get; set; }
    }
}