using Microsoft.EntityFrameworkCore;
namespace StudentInformationSystem.Models
{
    public class SISDBContext : DbContext
    {
        public SISDBContext(DbContextOptions<SISDBContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
