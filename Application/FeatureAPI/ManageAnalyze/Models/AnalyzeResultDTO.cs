public class AnalyzeResultDTO
{
    public double TotalCost { get; set; }
    public int SuccessfulCases { get; set; }
    public int CompetitorsCount { get; set; }
    public int Score { get; set; }
    public string Recommendation { get; set; } = string.Empty;
    public List<string> Pros { get; set; } = new();
    public List<string> Cons { get; set; } = new();
}
