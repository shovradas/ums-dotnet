using System.Data.Entity;
using Ums.Entities;

namespace Ums.Infrastructure.Data.EF
{
    public class UmsDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DomainConfig> DomainConfigs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
