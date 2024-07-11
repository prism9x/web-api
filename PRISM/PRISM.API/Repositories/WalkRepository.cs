using Microsoft.EntityFrameworkCore;
using PRISM.API.Data;
using PRISM.API.Models.Domain;

namespace PRISM.API.Repositories
{
    public class WalkRepository(ApplicationDbContext context) : IWalkRepository
    {
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await context.AddAsync(walk);
            await context.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existWalk = await context.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existWalk == null)
            {
                return null;
            }
            context.Remove(existWalk);
            await context.SaveChangesAsync();
            return existWalk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await context.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await context.Walks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existWalk = await context.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existWalk == null)
            {
                return null;
            }

            existWalk.Name = walk.Name;
            existWalk.Description = walk.Description;
            existWalk.LengthInKm = walk.LengthInKm;
            existWalk.WalkImageUrl = walk.WalkImageUrl;

            existWalk.RegionId = walk.RegionId;
            existWalk.DifficultyId = walk.DifficultyId;

            await context.SaveChangesAsync();
            return existWalk;
        }
    }
}