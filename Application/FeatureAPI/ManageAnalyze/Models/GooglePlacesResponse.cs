public class GooglePlacesResponse
{
    public List<GooglePlaceResult> Results { get; set; } = new();
}

public class GooglePlaceResult
{
    public string Name { get; set; } = string.Empty;
}
