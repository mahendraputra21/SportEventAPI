using SportEventAPI.Features.SportEvents.Query.Model;
using SportEventAPI.Models;
using System.Threading.Tasks;

namespace SportEventAPI.Features.SportEvents.Services
{
    public interface ISportEventService
    {
        Task<Response> GetAsync(string token, int page, int perPage, int organizerId);
        Task<Response> GetByIdAsync(string token, int id);
        Task<Response> PostAsync(string token, CreateSportEventRequest request);
        Task<Response> PutAsync(string token, int id, CreateSportEventRequest request);
        Task<Response> DeleteAsync(string token, int id);
    }
}
