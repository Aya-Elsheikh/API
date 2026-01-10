public interface IScoringService
{
    int Calculate(
        int footfall,
        int competition,
        int demographics,
        int accessibility,
        int rental);
}
