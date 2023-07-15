using LondonHeathrow.Pa.Web.DataConfigurations;
using LondonHeathrow.Pa.Web.DataExtensions;
using Microsoft.EntityFrameworkCore;

namespace LondonHeathrow.Pa.Web.Data
{
	public class PaDbContext: DbContext
	{
        public PaDbContext(DbContextOptions options) : base(options) { }
        public DbSet<DeviceData> Devices { get; set; }
        public DbSet<UserData> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDataConfiguration).Assembly);

            modelBuilder.SetForeignKeyConstraints();
        }
    }
}