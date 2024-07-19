using PRISM.API.Models.Domain;

namespace PRISM.API.Repositories
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public Task<Region> CreateAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Region>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Region?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> UpdateAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}