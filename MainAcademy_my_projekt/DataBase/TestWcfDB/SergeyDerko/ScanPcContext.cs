using System.Data.Entity;
using TestWcfTypes.SergeyDerko;

namespace TestWcfDB.SergeyDerko
{
    public class ScanPcContext : Context
    {
        public DbSet<ScanPcBd> ScanPcBds { get; set; }
    }
}
