using SportEventAPI.Features.SportEvents.Query.Model;
using SportEventAPI.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NLog;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SportEventAPI.Features.SportEvents.Services
{
    public class SportEventService : ISportEventService
    {
        HttpClient _httpClient;
        private readonly ILogger _logger;
        JsonSerializerSettings _jsonSerializerSettings;
        public SportEventService()
        {
            _logger = LogManager.GetCurrentClassLogger(); ;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(GlobalVar.BaseURL);
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
        }

        public async Task<Response> GetAsync(string token, int page, int perPage, int organizerId)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var url = organizerId > 0 ? $"/api/v1/sport-events?page={page}&perPage={perPage}&organizerId={organizerId}" :
                                            $"/api/v1/sport-events?page={page}&perPage={perPage}";
                using var httpResponse =
                   await _httpClient.GetAsync(url);

                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success GET API : {url}");
                return new ResponseSuccess(JsonConvert.DeserializeObject<ListSportEventReponse>(contents));

            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }

        public async Task<Response> GetByIdAsync(string token, int id)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var url = $"/api/v1/sport-events/{id}";

                using var httpResponse =
                   await _httpClient.GetAsync(url);

                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success GET API : {url}");
                return new ResponseSuccess(JsonConvert.DeserializeObject<SportEventResponse>(contents));

            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }

        public async Task<Response> PostAsync(string token, CreateSportEventRequest request)
        {
            try
            {

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var requestJson = new StringContent(
                    JsonConvert.SerializeObject(request, _jsonSerializerSettings),
                    Encoding.UTF8,
                    "application/json");

                using var httpResponse =
                    await _httpClient.PostAsync("/api/v1/sport-events", requestJson);

                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success POST API : /api/v1/sport-events");
                return new ResponseSuccess(JsonConvert.DeserializeObject<CreateSportEventResponse>(contents));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }

        public async Task<Response> PutAsync(string token, int id, CreateSportEventRequest request)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var requestJson = new StringContent(
                    JsonConvert.SerializeObject(request, _jsonSerializerSettings),
                    Encoding.UTF8,
                    "application/json");

                using var httpResponse =
                    await _httpClient.PutAsync($"/api/v1/sport-events/{id}", requestJson);

                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success PUT API : /api/v1/sport-events/{id}");
                return new ResponseSuccess(JsonConvert.DeserializeObject<CreateSportEventRequest>(contents));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }

        public async Task<Response> DeleteAsync(string token, int id)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using var httpResponse =
                    await _httpClient.DeleteAsync($"/api/v1/sport-events/{id}");

                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success DELETE API : /api/v1/sport-events/{id}");
                return new ResponseSuccess(JsonConvert.DeserializeObject<dynamic>(contents));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }
    }
}
