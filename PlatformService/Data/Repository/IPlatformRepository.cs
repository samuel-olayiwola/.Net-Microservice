using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Data.Repository
{
    public interface IPlatformRepository
    {
        bool saveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        Platform AddPlatform(Platform platform);
    }
}
