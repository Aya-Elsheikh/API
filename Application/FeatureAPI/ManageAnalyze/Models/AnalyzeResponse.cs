public class AnalyzeResponse
{
    public int Score { get; set; }
    public string Recommendation { get; set; } = string.Empty;
    public List<string> Pros { get; set; } = new();
    public List<string> Cons { get; set; } = new();
}
