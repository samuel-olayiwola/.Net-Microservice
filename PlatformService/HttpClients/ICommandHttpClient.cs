using PlatformService.Dtos;

namespace PlatformService.HttpClients
{
    public interface ICommandHttpClient
    {
        Task SendCommand(PlatformResponseDto msg);
    }
}
