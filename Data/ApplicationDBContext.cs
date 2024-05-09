using Microsoft.EntityFrameworkCore;
using student_management_backend.Models.Entities;

namespace student_management_backend.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
