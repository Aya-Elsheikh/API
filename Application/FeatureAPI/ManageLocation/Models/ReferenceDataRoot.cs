using System.Text.Json.Serialization;

public class ReferenceDataRoot
{
    [JsonPropertyName("emirates")]
    public List<LocationDTO> Emirates { get; set; } = new();
    [JsonPropertyName("concepts")]
    public List<ConceptDTO> Concepts { get; set; } = new();
}
