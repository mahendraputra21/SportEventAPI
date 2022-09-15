using SportEventAPI.Domain;
using SportEventAPI.Features.Users.Query.Model;
using SportEventAPI.Models;
using System.Threading.Tasks;

namespace SportEventAPI.Services
{
    public interface IUserService
    {
        Task<Response> CreateUserAsync(UserDto request);
        Task<Response> LoginAsync(UserDto request);
        Task<Response> GetByIdAsync(UserDto request, string token);
        Task<Response> PutAsync(UserDto request, int id, string token);
        Task<Response> DeleteAsync(UserDto request, string token);

    }
}
