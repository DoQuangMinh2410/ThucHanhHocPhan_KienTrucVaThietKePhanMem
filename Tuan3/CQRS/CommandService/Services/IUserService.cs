using CommandService.Models;
namespace CommandService.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
    }
}
