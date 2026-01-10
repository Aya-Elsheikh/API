using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

public class GooglePlacesClient
{
    private readonly HttpClient _http;
    private readonly string _apiKey;

    public GooglePlacesClient(HttpClient http, IConfiguration config)
    {
        _http = http;
        _apiKey = config["Google:ApiKey"]!;
    }

    public async Task<int> CountCompetitorsAsync(
    double lat,
    double lng,
    string keyword,
    int radius = 1000)
    {
        var url =
            $"https://maps.googleapis.com/maps/api/place/textsearch/json" +
            $"?query={keyword}" +
            $"&location={lat},{lng}" +
            $"&radius={radius}" +
            $"&key={_apiKey}";

        var httpResponse = await _http.GetAsync(url);
        var raw = await httpResponse.Content.ReadAsStringAsync();
        var response = await _http.GetFromJsonAsync<GooglePlacesResponse>(url);

        return response?.Results?.Count ?? 0;
    }

}
