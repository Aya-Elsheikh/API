using System.Text.Json.Serialization;

public class ConceptDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = "";

    [JsonPropertyName("googlePlaceType")]
    public string GooglePlaceType { get; set; } = "";
}
