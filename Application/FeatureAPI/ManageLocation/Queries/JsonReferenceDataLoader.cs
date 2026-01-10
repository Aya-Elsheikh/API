using System.Text.Json;

public class JsonReferenceDataLoader
{
    public ReferenceDataRoot Data { get; }

    public JsonReferenceDataLoader()
    {
        var path = Path.Combine(
            AppContext.BaseDirectory,
            "ReferenceData",
            "ReferenceData.json");

        if (!File.Exists(path))
            throw new FileNotFoundException("ReferenceData.json not found", path);

        var json = File.ReadAllText(path);

        Data = JsonSerializer.Deserialize<ReferenceDataRoot>(
            json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
}
