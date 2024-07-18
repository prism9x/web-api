using Microsoft.AspNetCore.Mvc;
using PRISM.API.Models.Domain;

namespace PRISM.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync(string? filterOn = null, 
            string? filterQuery = null, 
            string? sortBy = null, 
            bool isAscending = true,
            int pageNumber = 1,
            int pageSize = 1000);

        Task<Walk?> GetByIdAsync(Guid id);

        Task<Walk> CreateAsync(Walk region);

        Task<Walk?> UpdateAsync(Guid id, Walk walk);

        Task<Walk?> DeleteAsync(Guid id);
    }
}