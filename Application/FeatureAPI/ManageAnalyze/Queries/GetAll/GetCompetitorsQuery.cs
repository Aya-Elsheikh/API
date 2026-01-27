namespace Application.FeatureAPI.ManageAnalyze.Queries.GetAll
{
    using MediatR;
    using System.Text.Json;

    public class GetCompetitorsQuery : IRequest<int>
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Category { get; set; } = string.Empty;
        public int Radius { get; set; } = 500;
    }
    public class GetCompetitorsQueryHandler
        : IRequestHandler<GetCompetitorsQuery, int>
    {
        private readonly HttpClient _http;

        public GetCompetitorsQueryHandler(HttpClient http)
        {
            _http = http;
        }

        public async Task<int> Handle(
            GetCompetitorsQuery request,
            CancellationToken cancellationToken)
        {
            var osmTag = request.Category.ToLower() switch
            {
                "restaurant" => @"[""amenity""=""restaurant""]",
                "coffee shop / cafe" => @"[""amenity""=""cafe""]",
                "grocery store" => @"[""shop""=""supermarket""]",
                "laundry service" => @"[""shop""=""laundry""]",
                "men salon" => @"[""shop""=""hairdresser""]",
                "beauty salon / ladies" => @"[""shop""=""beauty_salon""]",
                "fashion boutique" => @"[""shop""=""clothes""]",
                "fitness center" => @"[""leisure""=""fitness_centre""]",
                "tech service / repair" => @"[""shop""=""electronics""]",
                "florist" => @"[""shop""=""florist""]",
                "pharmacy" => @"[""amenity""=""pharmacy""]",
                "general medical clinic" => @"[""amenity""=""clinic""]",
                "dental clinic" => @"[""amenity""=""dentist""]",
                "poly clinic" => @"[""amenity""=""clinic""]",
                "specialized med. center" => @"[""amenity""=""hospital""]",
                "dermatology & aesthetic" => @"[""amenity""=""clinic""]",
                "medical laboratory" => @"[""amenity""=""clinic""]",
                "physiotherapy & rehab" => @"[""amenity""=""clinic""]",
                "pediatric clinic" => @"[""amenity""=""clinic""]",
                "veterinary clinic" => @"[""amenity""=""veterinary""]",
                "home healthcare" => @"[""healthcare""=""homecare""]",
                "nutrition & diet center" => @"[""amenity""=""clinic""]",
                "optical shop / eye care‏" => @"[""shop""=""optician""]",
                _ => @"[""amenity""=""restaurant""]"
            };

            var query = $@"
                [out:json][timeout:100];
                (
                  node{osmTag}(around:{request.Radius},{request.Lat},{request.Lng});
                  way{osmTag}(around:{request.Radius},{request.Lat},{request.Lng});
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
                    content,
                    cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to call Overpass API", ex);
            }

            var responseText = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode ||
                string.IsNullOrWhiteSpace(responseText) ||
                !responseText.TrimStart().StartsWith("{"))
            {
                return new int();
            }

            var names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            try
            {
                using var doc = JsonDocument.Parse(responseText);

                if (!doc.RootElement.TryGetProperty("elements", out var elements))
                    return new int();

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
            catch (JsonException)
            {
                return new int();
            }

            return names.Count;
        }
    }
}
