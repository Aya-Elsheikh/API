using System.Text.Json;

namespace Infrastructure.External; 

public class OverpassClient
{
    private readonly HttpClient _http;

    public OverpassClient(HttpClient http)
    {
        _http = http;
    }

    //    public async Task<int> CountCompetitorsAsync(
    //        double lat,
    //        double lng,
    //        string category,
    //        int radius = 500)
    //    {
    //        var osmTag = category switch
    //        {
    //            "restaurant" => @"[""amenity""=""restaurant""]",
    //            "cafe" => @"[""amenity""=""cafe""]",
    //            _ => @"[""amenity""=""restaurant""]"
    //        };

    //        var query = $@"
    //[out:json];
    //(
    //  node{osmTag}(around:{radius},{lat},{lng});
    //  way{osmTag}(around:{radius},{lat},{lng});
    //);
    //out body;
    //";

    //        var content = new FormUrlEncodedContent(
    //            new Dictionary<string, string>
    //            {
    //                ["data"] = query
    //            });

    //        var response = await _http.PostAsync(
    //            "https://overpass-api.de/api/interpreter",
    //            content);

    //        var json = await response.Content.ReadAsStringAsync();

    //        using var doc = JsonDocument.Parse(json);
    //        return doc.RootElement
    //            .GetProperty("elements")
    //            .GetArrayLength();
    //    }

    public async Task<int> CountCompetitorsAsync(
    double lat,
    double lng,
    string category,
    int radius = 500)
    {
        var names = await GetCompetitorNamesAsync(lat, lng, category, radius);
        return names.Count;
    }


    public async Task<List<string>> GetCompetitorNamesAsync(
    double lat,
    double lng,
    string category,
    int radius = 500)
    {
        var osmTag = category switch
        {
            "restaurant" => @"[""amenity""=""restaurant""]",
            "cafe" => @"[""amenity""=""cafe""]",
            _ => @"[""amenity""=""restaurant""]"
        };

        var query = $@"
[out:json][timeout:100];
(
  node{osmTag}(around:{radius},{lat},{lng});
  way{osmTag}(around:{radius},{lat},{lng});
);
out tags;
";

        using var content = new FormUrlEncodedContent(
            new Dictionary<string, string>
            {
                ["data"] = query
            });

        HttpResponseMessage response;

        try
        {
            response = await _http.PostAsync(
                "https://overpass-api.de/api/interpreter",
                content);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to call Overpass API", ex);
        }

        var responseText = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode ||
            string.IsNullOrWhiteSpace(responseText) ||
            !responseText.TrimStart().StartsWith("{"))
        {
            Console.WriteLine("Overpass invalid response:");
            Console.WriteLine(responseText);

            return new List<string>(); 
        }

        var names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        try
        {
            using var doc = JsonDocument.Parse(responseText);

            if (!doc.RootElement.TryGetProperty("elements", out var elements))
                return new List<string>();

            foreach (var element in elements.EnumerateArray())
            {
                if (!element.TryGetProperty("tags", out var tags))
                    continue;

                if (!tags.TryGetProperty("name", out var nameProp))
                    continue;

                var name = nameProp.GetString();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    names.Add(name.Trim());
                }
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine("JSON parsing error:");
            Console.WriteLine(ex.Message);
            Console.WriteLine(responseText);

            return new List<string>();
        }

        return names.ToList();
    }
}
