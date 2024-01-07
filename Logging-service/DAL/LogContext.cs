using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions options) : base(options) {}
    
        public DbSet<Log> Logs { get; set; }
    }
}