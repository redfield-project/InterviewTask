using InterviewTask.Common.Models.DTOs;
using InterviewTask.Common.Models.Responses;
using System.Net.Http.Json;

namespace InterviewTask.WebApp.Clients;

public class AppHttpClient
{
    private readonly ILogger<AppHttpClient> _logger;
    private readonly HttpClient _http;

    public AppHttpClient(ILogger<AppHttpClient> logger,  HttpClient http)
    {
        _logger = logger;
        _http = http;
    }

    public async Task<int[]?> GetStoresListAsync()
    {
        try
        {
            var response = await _http.GetAsync("api/store/list");
            var storesList = await _http.GetFromJsonAsync<int[]>("api/store/list");
            if (storesList == null)
            {
                return null;
            }
            return storesList;

        }
        catch (Exception ex)
        {
            _logger.LogError("{ex}", ex.Message);
            return null;
        }
    }

    public async Task<StatisticsResponse?> GetStatisticsAsync(StatisticsDTO statisticsDTO)
    {
        var requestUri = $"api/store/statistics/{statisticsDTO.StoreId}";
        try
        {
            var response = await _http.GetAsync(requestUri);
            var succeeded = response.IsSuccessStatusCode;
            if (!succeeded)
            {
                var message = await response.Content.ReadAsStringAsync();
                return new StatisticsResponse
                {
                    Status = succeeded,
                    Message = message
                };
            }

            return await _http.GetFromJsonAsync<StatisticsResponse>(requestUri);

        }
        catch (Exception ex)
        {
            _logger.LogError("{ex}", ex.Message);

            return new StatisticsResponse
            {
                Status = false,
                Message = ex.Message
            };
        }
    }
}
