using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PRISM.API.Data
{
    public class AppAuthDbContext : IdentityDbContext
    {
        public AppAuthDbContext(DbContextOptions<AppAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "ccaa2815-460b-4d77-8bcc-88bc7d2a049d";
            var writerRoleId = "28b470c2-b3f4-4e4c-9cdd-ee811d059103";

            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole()
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }

            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
