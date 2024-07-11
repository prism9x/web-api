using Microsoft.EntityFrameworkCore;
using PRISM.API.Models.Domain;

namespace PRISM.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            var difficulties = new List<Difficulty>{
                new Difficulty
                {
                    Id = Guid.Parse("e3b3b61e-894d-4f41-a1b1-87efc5c526a4"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("ffa84219-5315-46b6-a3c2-724c22fe5004"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("c3042129-aeb0-40fb-8406-74039e81e7f3"),
                    Name = "Hard"
                }
            };

            var regions = new List<Region>{
                new Region
                {
                    Id = Guid.Parse("041e5528-e2a1-4864-b1dd-03358ca540f3"),
                    Code = "HNC",
                    Name = "Hà Nội",
                    RegionImageUrl = "https://picsum.photos/200/300"
                },
                new Region
                {
                    Id = Guid.Parse("98f959d9-7399-4f63-be6d-96d1f53bbda6"),
                    Code = "BNC",
                    Name = "Bắc Ninh",
                    RegionImageUrl = "https://picsum.photos/200/300"
                },
                new Region
                {
                    Id = Guid.Parse("23e92c3d-6c5a-467c-9c11-7a0cced1c9fb"),
                    Code = "HCM",
                    Name = "Hồ Chí Minh",
                    RegionImageUrl = "https://picsum.photos/200/300"
                },
                new Region
                {
                    Id = Guid.Parse("53030a9a-4557-40ca-8808-82c9a36d14bc"),
                    Code = "DNC",
                    Name = "Đà Nẵng",
                    RegionImageUrl = "https://picsum.photos/200/300"
                },
                new Region
                {
                    Id = Guid.Parse("ef49d302-eb51-4fed-be02-18885af45742"),
                    Code = "VTC",
                    Name = "Vũng Tàu",
                    RegionImageUrl = "https://picsum.photos/200/300"
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}