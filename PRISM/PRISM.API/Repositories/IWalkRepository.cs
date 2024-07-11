using PRISM.API.Models.Domain;

namespace PRISM.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync();

        Task<Walk?> GetByIdAsync(Guid id);

        Task<Walk> CreateAsync(Walk region);

        Task<Walk?> UpdateAsync(Guid id, Walk walk);

        Task<Walk?> DeleteAsync(Guid id);
    }
}