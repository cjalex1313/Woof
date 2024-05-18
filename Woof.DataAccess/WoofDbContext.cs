using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Woof.DataAccess.DbMappings;
using Woof.Domain.Entities;

namespace Woof.DataAccess
{
    public class WoofDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Clinic> Clinics { get; set; }

        public WoofDbContext(DbContextOptions<WoofDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ClinicDbMapping.MapClinic(builder.Entity<Clinic>());
        }
    }


}
