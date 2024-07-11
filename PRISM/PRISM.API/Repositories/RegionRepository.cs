using Microsoft.EntityFrameworkCore;
using PRISM.API.Data;
using PRISM.API.Models.Domain;

namespace PRISM.API.Repositories
{
    public class RegionRepository(ApplicationDbContext context) : IRegionRepository
    {
        public async Task<Region> CreateAsync(Region region)
        {
            await context.AddAsync(region);
            await context.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existRegion = await context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existRegion == null)
            {
                return null;
            }
            context.Remove(existRegion);
            await context.SaveChangesAsync();
            return existRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await context.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await context.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existRegion = await context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existRegion == null)
            {
                return null;
            }

            existRegion.Code = region.Code;
            existRegion.Name = region.Name;
            existRegion.RegionImageUrl = region.RegionImageUrl;

            await context.SaveChangesAsync();
            return existRegion;
        }
    }
}