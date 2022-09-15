using SportEventAPI.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NLog;
using SportEventAPI.Domain;

namespace SportEventAPI.Services
{
    public class OrganizerService : IOrganizerService
    {
        HttpClient _httpClient;
        private readonly ILogger _logger;
        JsonSerializerSettings _jsonSerializerSettings;
       
        public OrganizerService()
        {
            _logger = LogManager.GetCurrentClassLogger(); ;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(GlobalVar.BaseURL);
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
        }
        public async Task<Response> GetAsync(string token, int page, int perPage)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using var httpResponse =
                   await _httpClient.GetAsync($"/api/v1/organizers?page={page}&perPage={perPage}");


                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success GET API : /api/v1/organizers?page={page}&perPage={perPage}");
                return new ResponseSuccess(JsonConvert.DeserializeObject<ListOrganizersResponse>(contents));

            } catch(Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }

        public async Task<Response> GetByIdAsync(string token, int id)
        {
            try { 
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using var httpResponse =
                   await _httpClient.GetAsync($"/api/v1/organizers/{id}");


                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success GET API : /api/v1/organizers/{id}");
                return new ResponseSuccess(JsonConvert.DeserializeObject<OrganizerResponse>(contents));
            } catch(Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }

        public async Task<Response> DeleteAsync(string token, int id)
        {
            try { 
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using var httpResponse =
                   await _httpClient.DeleteAsync($"/api/v1/organizers/{id}");


                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success DELETE API : /api/v1/organizers/{id}");
                return new ResponseSuccess(JsonConvert.DeserializeObject<dynamic>(contents));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }

        public async Task<Response> PostAsync(string token, OrganizerDto request)
        {
            try
            {

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var requestJson = new StringContent(
                    JsonConvert.SerializeObject(request, _jsonSerializerSettings),
                    Encoding.UTF8,
                    "application/json");

                using var httpResponse =
                    await _httpClient.PostAsync("/api/v1/organizers", requestJson);

                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success POST API : /api/v1/organizers");
                return new ResponseSuccess(JsonConvert.DeserializeObject<OrganizerResponse>(contents));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }

        public async Task<Response> PutAsync(string token, int id, OrganizerDto request)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var requestJson = new StringContent(
                    JsonConvert.SerializeObject(request, _jsonSerializerSettings),
                    Encoding.UTF8,
                    "application/json");

                using var httpResponse =
                    await _httpClient.PutAsync($"/api/v1/organizers/{id}", requestJson);

                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success PUT API : /api/v1/organizers/{id}");
                return new ResponseSuccess(JsonConvert.DeserializeObject<OrganizerResponse>(contents));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }
    }
}
