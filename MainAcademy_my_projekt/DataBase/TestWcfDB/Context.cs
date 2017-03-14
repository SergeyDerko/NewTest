using System.Data.Entity;

namespace TestWcfDB
{
    public class Context : DbContext
    {
        public Context() : base("DBConnection")
        {
        }
    }
}