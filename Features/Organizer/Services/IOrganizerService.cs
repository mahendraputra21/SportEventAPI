using SportEventAPI.Domain;
using SportEventAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportEventAPI.Services
{
    public interface IOrganizerService
    {
        Task<Response> GetAsync(string token, int page, int perPage);
        Task<Response> GetByIdAsync(string token, int id);
        Task<Response> PostAsync(string token, OrganizerDto request);
        Task<Response> PutAsync(string token, int id, OrganizerDto request);
        Task<Response> DeleteAsync(string token, int id);

    }
}
