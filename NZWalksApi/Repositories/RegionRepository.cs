using Microsoft.EntityFrameworkCore;
using NZWalksApi.Data;
using NZWalksApi.Models.Domain;

namespace NZWalksApi.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private NZWalksDbContext _dbContext;

        public RegionRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            // This is to get the data in synchronous way
            // return _dbContext.Regions.ToList();
            // This is to get the data in asynchronous way
            return await _dbContext.Regions.ToListAsync();
        }
    }
}