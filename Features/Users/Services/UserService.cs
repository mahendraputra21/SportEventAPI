using SportEventAPI.Features.Users.Query.Model;
using SportEventAPI.Models;
using Newtonsoft.Json;
using NLog;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SportEventAPI.Domain;

namespace SportEventAPI.Services
{
    public class UserService : IUserService
    {
        HttpClient _httpClient;
        private readonly ILogger _logger;
        JsonSerializerSettings _jsonSerializerSettings;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _logger = LogManager.GetCurrentClassLogger();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(GlobalVar.BaseURL);
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            _mapper = mapper;
        }
       
        public async Task<Response> LoginAsync(UserDto request)
        {
            try
            {
                var requestJson = new StringContent(
                    JsonConvert.SerializeObject(request, _jsonSerializerSettings),
                    Encoding.UTF8,
                    "application/json");

                using var httpResponse =
                    await _httpClient.PostAsync("/api/v1/users/login", requestJson);

                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success POST API : /api/v1/users/login");
                return new ResponseSuccess(JsonConvert.DeserializeObject<LoginResponse>(contents));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }

        public async Task<Response> CreateUserAsync(UserDto request)
        {
            try
            {
                var requestJson = new StringContent(
                    JsonConvert.SerializeObject(request, _jsonSerializerSettings),
                    Encoding.UTF8,
                    "application/json");

                using var httpResponse =
                    await _httpClient.PostAsync("/api/v1/users", requestJson);

                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success POST API : /api/v1/users");
                return new ResponseSuccess(JsonConvert.DeserializeObject<CreateUserResponse>(contents));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }

        public async Task<Response> GetByIdAsync(UserDto request, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using var httpResponse =
                    await _httpClient.GetAsync($"/api/v1/users/{request.Id}");

                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success GET API : /api/v1/users/{request.Id}");
                return new ResponseSuccess(JsonConvert.DeserializeObject<GetUserByIdResponse>(contents));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }

        public async Task<Response> PutAsync(UserDto request, int id, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var requestJson = new StringContent(
                   JsonConvert.SerializeObject(request, _jsonSerializerSettings),
                   Encoding.UTF8,
                   "application/json");

                using var httpResponse =
                    await _httpClient.PutAsync($"/api/v1/users/{id}", requestJson);

                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success PUT API : /api/v1/users/{id}");
                return new ResponseSuccess(JsonConvert.DeserializeObject<GetUserByIdResponse>(contents));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }

        public async Task<Response> DeleteAsync(UserDto request, string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using var httpResponse =
                    await _httpClient.DeleteAsync($"/api/v1/users/{request.Id}");

                httpResponse.EnsureSuccessStatusCode();
                var contents = await httpResponse.Content.ReadAsStringAsync();
                _logger.Info($"Success DELETE API : /api/v1/users/{request.Id}");

                return new ResponseSuccess(JsonConvert.DeserializeObject<GetUserByIdResponse>(contents));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException);
                return new ResponseFailed(ex.Message);
            }
        }
    }
}
