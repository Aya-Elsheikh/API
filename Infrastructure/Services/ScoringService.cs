public class ScoringService : IScoringService
{
    public int Calculate(
        int footfall,
        int competition,
        int demographics,
        int accessibility,
        int rental)
    {
        return (int)Math.Round(
            footfall * 0.30 +
            competition * 0.25 +
            demographics * 0.20 +
            accessibility * 0.15 +
            rental * 0.10);
    }
}
