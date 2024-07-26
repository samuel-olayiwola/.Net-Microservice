using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Data.Repository
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDBContext _dbContext;
        public PlatformRepository(AppDBContext context)
        {
            _dbContext = context;
        }
        public Platform AddPlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _dbContext.Platforms.Add(platform);
            return platform;
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _dbContext.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _dbContext.Platforms.FirstOrDefault(x => x.Id == id);
        }

        public bool saveChanges()
        {
            return _dbContext.SaveChanges() >= 0;
        }
    }
}
